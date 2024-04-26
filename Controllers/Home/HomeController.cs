using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
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

        private List<TrackerViewModel> trackersVM;
        public HomeController(ILogger<HomeController> logger, RedmineContext context)
        {
            _logger = logger;
            this.context = context;
        }

        #region create issue
        // GET: HomeController
        [Route("/Web-Support")]
        [Authorize]
        public async Task<ActionResult> AddIssue()
        {
            if (Account.Account.isAuthorized == false)
            {
                return Redirect("/Web-Support/logout");
            }
           
            
            var projects = await context.Projects.ToListAsync();
            var trackers = await context.Trackers.ToListAsync();

            trackersVM = new List<TrackerViewModel>();

            ViewBag.Projects = new SelectList(projects, "Id", "Name");
            ViewBag.Trackers = new SelectList(trackers, "Id", "Name");

            return View();
        }

        [HttpPost]
        [Route("/Web-Support")]
        [Authorize]
        public async Task<ActionResult> AddIssueAsync(string projectID, string Id, string subject, string description)
        {
            if (/*string.IsNullOrEmpty(project) ||*/ string.IsNullOrEmpty(Id))
            {
                ViewBag.CreateResult = "Заполните все поля";
                return View("AddIssue");
            }
            else
            {
                var created = DateTime.Now;

                var idTrack = Convert.ToInt32(Id);
                var proj = await context.ProjectsTrackers.Where(t => t.TrackerId == idTrack).FirstAsync();


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

                    });
                await context.SaveChangesAsync();
                ViewBag.CreateResult = "Задание создано";

                var track = await context.Trackers.FindAsync(idTrack);

                var subjectMess = $"\nНовая задача: {subject}";
                var message = $"Новая задача: {track.Name}" +
                    $"\nТема: {subject}" +
                    $"\nОписание: {description}" +
                    $"\nОт: {Account.Account.currentUser.Firstname + ' ' + Account.Account.currentUser.Lastname}";

                var admins = await context.Users.Where(u => u.Admin == true).ToListAsync();


                string encodedUrl = System.Net.WebUtility.UrlEncode(message);
                var urlmsg = tgMessage + encodedUrl;

                if (proj.ProjectId == 2)
                {
                    using (WebClient client = new())
                    {
                        string response = client.DownloadString(urlmsg);
                        await Console.Out.WriteLineAsync(response);
                    }
                }
               
                return View("AddIssue");
            }

        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        [Route("/Web-Support/manager/GetTrackerByProjectId")]
        public async Task<JsonResult> GetTrackerByProjectId(int projectID)
        {
            var tracksProject = await context.ProjectsTrackers.Where(t => t.ProjectId == projectID).ToListAsync();
            List<int> ids = new List<int>();
            foreach (var track in tracksProject)
            {
                ids.Add(track.TrackerId);
            }
            var p = await context.Trackers.Where(t => ids.Contains(t.Id)).ToListAsync();
            return Json(p);
        }

    }
}