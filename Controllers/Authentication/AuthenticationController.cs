using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebSupport.Models;
using RedmineLibrary.Authentication;

namespace WebSupport.Controllers.Authentication
{
    public class AuthenticationController : Controller
    {

        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            if (Login.Login_UsernamePassword(username, password))
            {
                ViewBag.username = string.Format("Successfull logged-in", username);
                return RedirectToRoute("default", new { controller = "Home", action = "Index" });
            }
            else
            {
                ViewBag.username = string.Format("Login Failed", username);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
