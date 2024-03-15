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
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CustomFieldEnumeration> CustomFieldEnumerations { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<CustomFieldsProject> CustomFieldsProjects { get; set; }
        public DbSet<CustomFieldsRole> CustomFieldsRoles { get; set; }
        public DbSet<CustomFieldsTracker> CustomFieldsTrackers { get; set; }
        public DbSet<CustomValue> CustomValues { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<EnabledModule> EnabledModules { get; set; }
        public DbSet<Enumeration> Enumerations { get; set; }
        public DbSet<GroupsUsers> GroupsUsers { get; set; }
        public DbSet<Import> Imports { get; set; }
        public DbSet<ImportItem> ImportItems { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueCategory> IssueCategories { get; set; }
        public DbSet<IssueRelation> IssueRelations { get; set; }
        public DbSet<IssueStatus> IssueStatuses { get; set; }
        public DbSet<JournalDetail> JournalDetails { get; set; }
        public DbSet<Member>  Members { get; set; }
        public DbSet<MemberRole> MemberRoles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<New> News{ get; set; }
        public DbSet<Project>  Projects{ get; set; }
        public DbSet<ProjectTracker> ProjectTrackers{ get; set; }
        public DbSet<Query>  Queries{ get; set; }
        public DbSet<QueryRole> QueryRoles { get; set; }
        public DbSet<Role>  Roles{ get; set; }
        public DbSet<TimeEntry> TimeEntries{ get; set; }
        public DbSet<Token> Tokens{ get; set; }
        public DbSet<Tracker> Trackers{ get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
           // Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseMySql(
                configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(5, 6, 40))
                ) ;
        }
    }
}
