using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebSupport.Models;
using RedmineLibrary.Repository;
using Microsoft.AspNetCore.Authorization;
using RedmineLibrary.Servieces;
using RedmineLibrary.Authentication;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace WebSupport.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: HomeController
        [Route("/")]
        [Authorize]
        public ActionResult AddIssue()
        {
            if (RedmineLibrary.Authentication.Login.User == null)
            {
                return Redirect("/logout");
            }

            return View();
        }

        [HttpPost]
        [Route("/")]
        [Authorize]
        public ActionResult AddIssue(string project, string tracker, string subject, string description)
        {
            if (string.IsNullOrEmpty(project)|| string.IsNullOrEmpty(tracker)) 
            {
                ViewBag.CreateResult = "Заполните все поля";
                return View("AddIssue");
            }
            else
            {
                Repository.CreateIssue(project, tracker, subject, description);
                ViewBag.CreateResult = "Задание создано";
                return View("AddIssue");
            }

        }

         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}