using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebSupport.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Xml;
using WebSupport.Account;
using WebSupport.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using WebSupport.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WebSupport.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        RedmineContext context;

        public HomeController(ILogger<HomeController> logger, RedmineContext context)
        {
            _logger = logger;
            this.context = context;
        }
        
        #region create issue
        // GET: HomeController
        [Route("/")]
        [Authorize]
        public ActionResult AddIssue()
        {
            if (Account.Account.isAuthorized == false)
            {
                return Redirect("/logout");
            }

            return View(context);
        }

        [HttpPost]
        [Route("/")]
        [Authorize]
        public async Task<ActionResult> AddIssueAsync(string project, string tracker, string subject, string description)
        {
            if (string.IsNullOrEmpty(project)|| string.IsNullOrEmpty(tracker)) 
            {
                ViewBag.CreateResult = "Заполните все поля";
                return View("AddIssue");
            }
            else
            {
             //   Repository.CreateIssue(project, tracker, subject, description);

                context.Issues.Add(
                    new Entities.Issue()
                    {
                        ProjectId = Convert.ToInt32(project),
                        TrackerId = Convert.ToInt32(tracker),
                        Subject= subject,
                        Description= description
                    });
                await context.SaveChangesAsync();
                ViewBag.CreateResult = "Задание создано";
                return View("AddIssue", context);
            }

        }
        #endregion

        #region manage


        [Route("/manage%0%panel")]
        [Authorize]
        public async Task<IActionResult> Manage()
        {
            var issues = await context.Issues.Where(i => i.CreatedOn > new DateTime(2024, 1, 1) && i.StatusId == 1).ToListAsync();
            List<IssueViewModel> issuesViewModel = new List<IssueViewModel>();
            foreach(var issue in issues)
            {
                var projectName = await context.Projects.FirstOrDefaultAsync(p=>p.Id==issue.ProjectId);
                var trackerName = await context.Trackers.FirstOrDefaultAsync(t=>t.Id==issue.TrackerId);
                var author = await context.Users.FindAsync(issue.AuthorId);

                issuesViewModel.Add(
                    new IssueViewModel(
                        issue,
                        projectName.Name,
                        trackerName.Name,
                        author.Firstname +' '+ author.Lastname
                        ));
            }
            return View(issuesViewModel);
        }
    
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}