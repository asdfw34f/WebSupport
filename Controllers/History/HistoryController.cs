using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSupport.Data;
using WebSupport.DataEntities;
using WebSupport.Models.ViewModels;

namespace WebSupport.Controllers.History
{
    public class HistoryController : Controller
    {
        private RedmineContext context;

        public HistoryController(RedmineContext context)
        {
            this.context = context;
            if (!Account.Account.currentUser.Admin)
            {
                Redirect("/");
            }
        }

        #region My issues

        [HttpGet]
        [Authorize]
        [Route("/account/history")]
        public async Task<IActionResult> History()
        {
            List<Issue> issues = new List<Issue>();
            if (Account.Account.currentUser.Admin)
            {
                issues = await context.Issues.Where(i => i.AssignedToId == Account.Account.currentUser.Id).OrderByDescending(i => i.CreatedOn).Take(100).ToListAsync();
            }
            else
            {
                Redirect("/");
            }

            MyIssueViewModel myIssuesViewModel = new MyIssueViewModel(context);
            myIssuesViewModel.issues = new List<IssueViewModel>();

            issues = issues.OrderByDescending(i => i.CreatedOn).ToList();

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

            return View("HistoryMyIssues", myIssuesViewModel);
        }

        #endregion
    }
}
