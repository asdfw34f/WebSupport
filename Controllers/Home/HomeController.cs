using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redmine.Net.Api.Types;
using RedmineLibrary.Servieces;
using System.Diagnostics;
using WebSupport.Controllers.Authentication;
using WebSupport.Models;

namespace WebSupport.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        
        private readonly List<Project> projects = Manager.DB.Projects;
        private readonly List<Tracker> trackers = Manager.DB.Trackers;
        private readonly List<Issue> issues = Manager.DB.Issues;

        public HomeController(ILogger<AuthenticationController> logger) 
        {
            _logger = logger;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
