using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebSupport.Data;
using WebSupport.DataEntities;
using WebSupport.Models;
using WebSupport.Models.ViewModels;

namespace WebSupport.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        RedmineContext context;
        private List<IssueViewModel> mainManageModel = new List<IssueViewModel>();
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
        public async Task<ActionResult> AddIssueAsync(/*string project, */string tracker, string subject, string description)
        {
            if (/*string.IsNullOrEmpty(project) ||*/ string.IsNullOrEmpty(tracker))
            {
                ViewBag.CreateResult = "Заполните все поля";
                return View("AddIssue");
            }
            else
            {
                //   Repository.CreateIssue(project, tracker, subject, description);
                var created = DateTime.Now;

                var idTrack = Convert.ToInt32(tracker);
                var proj =await  context.ProjectsTrackers.Where(t => t.TrackerId == idTrack).FirstAsync();


                context.Issues.Add(
                    new DataEntities.Issue()
                    {
                        /*ProjectId = Convert.ToInt32(project),*/
                        ProjectId = proj.ProjectId,
                        TrackerId = idTrack,
                        Subject = subject,
                        Description = description,
                        AuthorId = Account.Account.currentUser.Id,
                        StatusId = 1,
                        CreatedOn = created

                    }) ;
                await context.SaveChangesAsync();
                ViewBag.CreateResult = "Задание создано";

                var subjectMess = $"Новая задача: {subject}";
                var message = $"Текст задачи: {description}" +
                    $"\nОт: {Account.Account.currentUser.Firstname + ' ' + Account.Account.currentUser.Lastname}" +
                    $"\nВремя создания: {created.ToString()}";


                var admins = await context.Users.Where(u=> u.Admin == true).ToListAsync();


                return View("AddIssue", context);
            }

        }
        #endregion

        #region manage


        [Route("/manager/issue/new/{id?}")]
        [Authorize]
        public async Task<IActionResult> Manage(int? id = null)
        {
            List<Issue> issues = new List<Issue>();

            var allow = await context.Members.Where(m => m.UserId == Account.Account.currentUser.Id).Select(mp => mp.ProjectId).ToListAsync();

            var allowProjects = await context.Projects.Where(p => allow.Contains(p.Id)).ToListAsync();

            ViewData.Add("projects", allowProjects);

            if (id != null)
            {
                issues = await context.Issues.Where(i => i.StatusId == 1 && i.ProjectId == id).ToListAsync();
            }
            else
            {
                issues = await context.Issues.Where(i => i.StatusId == 1 && i.ProjectId == allowProjects[0].Id).ToListAsync();
            }

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
                        if (!string.IsNullOrEmpty(author.Lastname) && !string.IsNullOrEmpty(author.Firstname))
                        {
                            authorName = author.Lastname + ' ' + author.Firstname[0] + ".";
                        }
                        else if (!string.IsNullOrEmpty(authorName))
                        {
                            authorName = author.Firstname;
                        }

                    }
                    else
                    {
                        authorName = "Автор был удалён";
                    }
                    mainManageModel.Add(
                                            new IssueViewModel(
                                                issue,
                                                projectName.Name,
                                                projectName.Id,
                                                trackerName.Name,
                                                authorName
                                                ));
                }
            }

            return View(mainManageModel);
        }

        [HttpPost]
        [Route("/manager/issue/new/change")]
        [Authorize]
        public async Task<IActionResult> ChangedAsync(string value)
        {
            var allow = await context.Members.Where(m => m.UserId == Account.Account.currentUser.Id).Select(mp => mp.ProjectId).ToListAsync();

            var allowProjects = await context.Projects.Where(p => allow.Contains(p.Id)).ToListAsync();

            ViewData.Add("projects", allowProjects);

            int projectSelected = int.Parse(value);
            var project = await context.Projects.FindAsync(projectSelected);

            var issues = await context.Issues.Where(i => i.StatusId == 1 && i.ProjectId == projectSelected).ToListAsync();

            mainManageModel = new List<IssueViewModel>();
            if (issues.Count > 0)
            {
                issues.OrderByDescending(i => i.Id);
                foreach (var issue in issues)
                {
                    string projName = "";
                    if (project != null)
                    {
                        projName = project.Name;
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
                        if (!string.IsNullOrEmpty(author.Lastname) && !string.IsNullOrEmpty(author.Firstname))
                        {
                            authorName = author.Lastname + ' ' + author.Firstname[0] + ".";
                        }
                        else if (!string.IsNullOrEmpty(authorName))
                        {
                            authorName = author.Firstname;
                        }
                    }
                    else
                    {
                        authorName = "Автор был удалён";
                    }
                    mainManageModel.Add(new IssueViewModel(
                                                issue,
                                                projName,
                                                project.Id,
                                                trackerName.Name,
                                                authorName
                                                ));
                }
            }

            return View("Manage",mainManageModel);
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
            List<Issue> issues = new List<Issue>();
            if (Account.Account.currentUser.Admin)
            {
                issues = await context.Issues.Where(i => i.AssignedToId == Account.Account.currentUser.Id).OrderByDescending(i => i.Id).Take(100).ToListAsync();
            }
            else
            {
                issues = await context.Issues.Where(i => i.AuthorId == Account.Account.currentUser.Id).OrderByDescending(i => i.Id).Take(100).ToListAsync();
            }


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
                            projectName.Id,
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