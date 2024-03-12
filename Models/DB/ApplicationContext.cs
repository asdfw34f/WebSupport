using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSupport.Models.Entities;

namespace WebSupport.Models.DB
{
    public class ApplicationContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; } 
        public DbSet<Attachments> Attachments{ get; set; } 
        public DbSet<Watcher> Watchers{ get; set; } 
        public DbSet<Wiki> Wikis { get; set; } 
        public DbSet<WikiContent> WikiContents { get; set; }
        public DbSet<WikiContentVersion> WikiContentVersions{ get; set; }
        public DbSet<WikiPage> WikiPages { get; set; }
        public DbSet<WikiRedirect> WikiRedirects{ get; set; }
        public DbSet<Workflow> Workflows{ get; set; }
        public DbSet<AuthSource> AuthSources { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Changes> Changes { get; set; }
        public DbSet<ChangesetParent> ChangesetParents { get; set; }
        public DbSet<Changeset> Changesets { get; set; }
        public DbSet<ChangesetsIssue> ChangesetsIssues { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
           // Database.EnsureCreated();
        }

    }
}
