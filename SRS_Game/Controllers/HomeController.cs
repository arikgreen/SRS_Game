using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SRS_Game.Data;
using SRS_Game.Models;
using System.Diagnostics;

namespace SRS_Game.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SRS_GameDbContext _context;

        public HomeController(ILogger<HomeController> logger, SRS_GameDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var redirectUrl = Url.Action("UploadFile", "Home");
            
            return LocalRedirect(redirectUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        public IActionResult Chat()
        { 
            return View();
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFilePost(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file selected for upload...");

            string fileName = Path.GetFileName(file.FileName);
            string contentType = file.ContentType;

            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    file.CopyToAsync(memoryStream);

                    var attachement = new Attachement[]
                    { 
                        new(1, fileName, DateTime.Now, DateTime.Now, memoryStream.ToArray(), contentType)
                    };

                    _context.Attachements.AddRange(attachement);
                    _context.SaveChanges();
                }
            }
            catch
            {
                return BadRequest(new
                {
                    message = "Error saving file to the database."
                });
            }

            return RedirectToAction("Index", "Attachements");
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return RedirectToAction("UploadFile", "Home");
            }

            return LocalRedirect(returnUrl);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorView { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
