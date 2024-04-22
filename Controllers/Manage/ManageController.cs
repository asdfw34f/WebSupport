using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSupport.Data;
using WebSupport.DataEntities;
using WebSupport.Models.ViewModels;

namespace WebSupport.Controllers.Manage
{
    public class ManageController : Controller
    {
        private RedmineContext context;
        private List<IssueViewModel> mainManageModel = new List<IssueViewModel>();

        public ManageController(RedmineContext context)
        {
            this.context = context;
        }

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
                issues = await context.Issues.Where(i => i.StatusId == 1 && i.ProjectId == id).Take(100).ToListAsync();
            }
            else
            {
                issues = await context.Issues.Where(i => i.StatusId == 1 && i.ProjectId == allowProjects[0].Id).Take(100).ToListAsync();
            }

            issues = issues.OrderByDescending(i => i.CreatedOn).ToList();

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

            return View("Manage", mainManageModel);
        }


        [HttpPost]
        [Authorize]
        [Route("/manager/issue/submit/{id?}")]
        public async Task<IActionResult> Submit(string id)
        {
            var issue = await context.Issues.FindAsync(int.Parse(id));
            if (issue != null)
            {
                issue.AssignedToId = Account.Account.currentUser.Id;
                issue.StatusId = 4;
                context.Issues.Update(issue);
                await context.SaveChangesAsync();
            }

            return Redirect("/manager/issue/new/");
        }

    }
}
