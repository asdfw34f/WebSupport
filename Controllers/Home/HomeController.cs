using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebSupport.Data;
using WebSupport.Models;
using WebSupport.Models.ViewModels;

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
            if (string.IsNullOrEmpty(project) || string.IsNullOrEmpty(tracker))
            {
                ViewBag.CreateResult = "Заполните все поля";
                return View("AddIssue");
            }
            else
            {
                //   Repository.CreateIssue(project, tracker, subject, description);

                context.Issues.Add(
                    new DataEntities.Issue()
                    {
                        ProjectId = Convert.ToInt32(project),
                        TrackerId = Convert.ToInt32(tracker),
                        Subject = subject,
                        Description = description,
                        AuthorId = Account.Account.currentUser.Id,
                        StatusId = 1,
                        CreatedOn = DateTime.Now
                        
                    });
                await context.SaveChangesAsync();
                ViewBag.CreateResult = "Задание создано";
                return View("AddIssue", context);
            }

        }
        #endregion

        #region manage


        [Route("/manager/issue/new")]
        [Authorize]
        public async Task<IActionResult> Manage()
        {
            var issues = await context.Issues.Where(i => i.StatusId == 1).ToListAsync();
            List<IssueViewModel> issuesViewModel = new List<IssueViewModel>();
            if (issues.Count > 0)
            {
                issues.OrderByDescending(i => i.Id);
                foreach (var issue in issues)
                {
                    var projectName = await context.Projects.FindAsync(issue.ProjectId);
                    string projName = "";
                    if (projectName != null)
                    {
                        projName = projectName.Name;
                    }
                    else
                    {
                        projName = "Проект был удалён";
                    }

                    var trackerName = await context.Trackers.FirstOrDefaultAsync(t => t.Id == issue.TrackerId);
                    string trackName = "";
                    if (trackerName != null)
                    {
                        trackName = trackerName.Name;
                    }
                    else
                    {
                        trackName = "Трекер был удалён";
                    }

                    var author = await context.Users.FindAsync(issue.AuthorId);
                    string authorName = "";
                    if (author != null)
                    {
                        authorName = author.Firstname + ' ' + author.Lastname;
                    }
                    else
                    {
                        authorName = "Автор был удалён";
                    }
                    issuesViewModel.Add(
                                            new IssueViewModel(
                                                issue,
                                                projectName.Name,
                                                trackerName.Name,
                                                "Автор был удалён"
                                                ));
                }
            }
            return View(issuesViewModel);
        }

        #endregion

        [HttpGet]
        [Authorize]
        [Route("manager/issue/submit/{id?}")]
        public async Task<IActionResult> Submit(int id)
        {
            var issue = await context.Issues.FindAsync(id);
            if (issue != null)
            {
                issue.AssignedToId = Account.Account.currentUser.Id;
                context.Issues.Update(issue);
                await context.SaveChangesAsync();
            }

            return Redirect("/manage%0%panel");
        }

        #region My issues

        [HttpGet]
        [Authorize]
        [Route("account/issue/myself")]
        public async Task<IActionResult> ViewMyIssue()
        {
            var issues = await context.Issues.Where(i => i.AuthorId == Account.Account.currentUser.Id).OrderByDescending(i => i.Id).Take(100).ToListAsync();


            MyIssueViewModel myIssuesViewModel = new MyIssueViewModel(context);

            myIssuesViewModel.issues = new List<IssueViewModel>();

            if (issues.Count > 0)
            {
                issues.OrderByDescending(i => i.Id);
                foreach (var issue in issues)
                {
                    var projectName = await context.Projects.FirstOrDefaultAsync(p => p.Id == issue.ProjectId);
                    string projName = "";
                    if (projectName != null)
                    {
                        projName = projectName.Name;
                    }
                    else
                    {
                        projName = "Проект был удалён";
                    }

                    var trackerName = await context.Trackers.FirstOrDefaultAsync(t => t.Id == issue.TrackerId);
                    string trackName = "";
                    if (trackerName != null)
                    {
                        trackName = trackerName.Name;
                    }
                    else
                    {
                        trackName = "Трекер был удалён";
                    }

                    var author = await context.Users.FindAsync(issue.AuthorId);
                    var status = await context.IssueStatuses.FindAsync(issue.StatusId);

                    myIssuesViewModel.issues.Add(
                        new IssueViewModel(
                            issue,
                            projectName.Name,
                            trackerName.Name,
                            author.Firstname + ' ' + author.Lastname,
                            status.Name
                            ));
                }

            }
            myIssuesViewModel.Statuses = await context.IssueStatuses.ToListAsync();

            return View(myIssuesViewModel);
        }

        #endregion


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}