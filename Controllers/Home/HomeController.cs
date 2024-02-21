using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Redmine.Net.Api.Types;
using RedmineLibrary.Servieces;
using System.Collections.Generic;
using System.Diagnostics;
using WebSupport.Controllers.Authentication;
using WebSupport.Models;

namespace WebSupport.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        

        public HomeController(ILogger<AuthenticationController> logger) 
        {
            _logger = logger;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            var projects = new List<SelectListItem>();
            foreach (Project p in Manager.DB.Projects)
            {
                projects.Add(new SelectListItem() { Text = p.Name, Value = p.Id.ToString() });
            }
            
            var trackers = new List<SelectListItem>();
            foreach (Tracker t in Manager.DB.Trackers)
            {
                trackers.Add(new SelectListItem() { Text = t.Name, Value = t.Id.ToString() });
            }

/*            var issues = new List<SelectList>();
            foreach (Issue i in Manager.DB.Issues)
            {
                issues.Add(new SelectListItem() { Text = i.Name, Value = i.Id.ToString() });
            }
*/

            ViewBag.Projects = projects;
            ViewBag.Trackers = trackers;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
