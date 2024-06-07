using Conforme.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Conforme.Data
{
    public class ConformeDbContext : IdentityDbContext<IdentityUser>
    {
        public ConformeDbContext(DbContextOptions<ConformeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Qualifications> Qualifications { get; set; }
        public DbSet<AssessTasks> AssessTasks { get; set; }
        public DbSet<Sites> Sites { get; set; }
        public DbSet<Units> Units { get; set; }
    }
}