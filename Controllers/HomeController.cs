using Microsoft.AspNetCore.Mvc;

namespace Conforme.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webhost;

        private readonly ILogger<HomeController> _logger;

        public HomeController(IWebHostEnvironment webhost, ILogger<HomeController> logger)
        {
            _webhost = webhost;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("navigate")]
        public async Task<IActionResult> Index(IFormFile navigate)
        {
            string fileName = "";
            string fileSavePath = "";
            try
            {
                if (navigate != null && navigate.Length > 0)
                {
                    //  the absolute path of directory that contains files 
                    string uploadsfolder = _webhost.WebRootPath + "/uploads";
                    if (!Directory.Exists(uploadsfolder))
                    {
                        Directory.CreateDirectory(uploadsfolder);
                    }

                    fileName = Path.GetFileName(navigate.FileName);
                    fileSavePath = Path.Combine(uploadsfolder, fileName);
                    using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                    {
                        await navigate.CopyToAsync(stream);
                        _logger.LogInformation("File Upload at this location:{fileSavePath}", fileSavePath);
                    }
                    TempData["SuccessMessage"] = "File Upload Sucessfully";
                    TempData["FileName"] = fileSavePath;
                    return Redirect("/navigate");
                }
            }
            catch (Exception ex)
            {
                // any Exception occurs log into the log file.
                _logger.LogError(ex, "An error occurred while uploading the image: {FileName}, Path: {FilePath}", fileName, fileSavePath);
                TempData["SuccessMessage"] = "File upload failed!!";
                return Redirect("/navigate");
            }
            TempData["SuccessMessage"] = "File upload failed!!";
            return Redirect("/navigate");

        }
    }
}
