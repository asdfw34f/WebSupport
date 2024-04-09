using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebSupport.Account;
using WebSupport.Models;

namespace WebSupport.Controllers.Authentication
{
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthentication _authenticater;
        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthentication authentication)
        {
            _logger = logger;
            _authenticater = authentication;
        }

        [Route("/login")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Index(string username, string password)
        {
            var res = await _authenticater.Log_In(username, password, HttpContext);
            if (res)
            {

                ViewBag.username = string.Format("Successfull logged-in", username);
                return Redirect("/");
            }
            else
            {
                Results.Unauthorized();
                return View("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
