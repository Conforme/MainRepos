using Conforme.Data;
using Conforme.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddDbContext<ConformeDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("ConformeConnection");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ConformeDbContext>();
    builder.Services.AddControllersWithViews();

    builder.WebHost.ConfigureKestrel(options =>
    {
        options.Limits.MaxRequestBodySize = 512 * 1024 * 1024;
    });

    builder.Services.AddTransient<IEmailSender, EmailSender>();
    builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);
    builder.Services.Configure<IdentityOptions>(options =>
    {
        // Default Password settings.
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 1;
    });

    builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
           o.TokenLifespan = TimeSpan.FromHours(3));

    builder.Services.ConfigureApplicationCookie(o =>
    {
        o.ExpireTimeSpan = TimeSpan.FromDays(5);
        o.SlidingExpiration = true;
    });
    // Add NLog as the logging provider

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddHsts(options =>
    {
        options.Preload = true;
        options.IncludeSubDomains = true;
        options.MaxAge = TimeSpan.FromDays(60);
        options.ExcludedHosts.Add("conforme.com.au");
        options.ExcludedHosts.Add("www.conforme.com.au");
    });

    var app = builder.Build();

    //RouteHandlerBuilder routeHandlerBuilder = app.MapGet("/", () => apiKey);
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }


    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}