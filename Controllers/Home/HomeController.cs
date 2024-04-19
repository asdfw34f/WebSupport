using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Net;
using System.Security.Policy;
using WebSupport.Data;
using WebSupport.DataEntities;
using WebSupport.Models;
using WebSupport.Models.ViewModels;

namespace WebSupport.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string tgMessage = "https://api.telegram.org/bot5171320687:AAGOti4QBF0hymVEqO0VW7ws-LWu5UuaGHk/sendMessage?chat_id=-1002068097170&text=";
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
        public async Task<ActionResult> AddIssue()
        {
            if (Account.Account.isAuthorized == false)
            {
                return Redirect("/logout");
            }

            List<AddIssueViewModel> list = new List<AddIssueViewModel>();
            var projects = await context.Projects.ToListAsync();
            var trackers = await context.Trackers.ToListAsync();
            
            foreach (var tracker in trackers) 
            {
                var projectId = await context.ProjectsTrackers.Where(w => w.TrackerId == tracker.Id).SingleAsync();
                list.Add(new AddIssueViewModel() { tracker = tracker, projectID =  projectId.ProjectId});
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

                var track = await context.Trackers.FindAsync(idTrack);

                var subjectMess = $"\nНовая задача: {subject}";
                var message = $"Новая задача: {track.Name}" +
                    $"\nТема: {subject}" +
                    $"\nОписание: {description}" +
                    $"\nОт: {Account.Account.currentUser.Firstname + ' ' + Account.Account.currentUser.Lastname}";
         
                var admins = await context.Users.Where(u=> u.Admin == true).ToListAsync();


                string encodedUrl = System.Net.WebUtility.UrlEncode(message);
                var urlmsg =tgMessage+ encodedUrl;


                using (WebClient client = new WebClient())
                {
                    string response = client.DownloadString(urlmsg);
                    await Console.Out.WriteLineAsync(response);
                }
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