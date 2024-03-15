using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using WebSupport.Models.Entities;

namespace WebSupport.Models.DB;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<AuthSource> AuthSources { get; set; }

    public virtual DbSet<Board> Boards { get; set; }

    public virtual DbSet<Change> Changes { get; set; }

    public virtual DbSet<Changeset> Changesets { get; set; }

    public virtual DbSet<ChangesetParent> ChangesetParents { get; set; }

    public virtual DbSet<ChangesetsIssue> ChangesetsIssues { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CustomField> CustomFields { get; set; }

    public virtual DbSet<CustomFieldEnumeration> CustomFieldEnumerations { get; set; }

    public virtual DbSet<CustomFieldsProject> CustomFieldsProjects { get; set; }

    public virtual DbSet<CustomFieldsRole> CustomFieldsRoles { get; set; }

    public virtual DbSet<CustomFieldsTracker> CustomFieldsTrackers { get; set; }

    public virtual DbSet<CustomValue> CustomValues { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<EmailAddress> EmailAddresses { get; set; }

    public virtual DbSet<EnabledModule> EnabledModules { get; set; }

    public virtual DbSet<Enumeration> Enumerations { get; set; }

    public virtual DbSet<GroupsUser> GroupsUsers { get; set; }

    public virtual DbSet<Import> Imports { get; set; }

    public virtual DbSet<ImportItem> ImportItems { get; set; }

    public virtual DbSet<Issue> Issues { get; set; }

    public virtual DbSet<IssueCategory> IssueCategories { get; set; }

    public virtual DbSet<IssueRelation> IssueRelations { get; set; }

    public virtual DbSet<IssueStatus> IssueStatuses { get; set; }

    public virtual DbSet<Journal> Journals { get; set; }

    public virtual DbSet<JournalDetail> JournalDetails { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberRole> MemberRoles { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<OpenIdAuthenticationAssociation> OpenIdAuthenticationAssociations { get; set; }

    public virtual DbSet<OpenIdAuthenticationNonce> OpenIdAuthenticationNonces { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectsTracker> ProjectsTrackers { get; set; }

    public virtual DbSet<QueriesRole> QueriesRoles { get; set; }

    public virtual DbSet<Query> Queries { get; set; }

    public virtual DbSet<Repository> Repositories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolesManagedRole> RolesManagedRoles { get; set; }

    public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<TimeEntry> TimeEntries { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<Tracker> Trackers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPreference> UserPreferences { get; set; }

    public virtual DbSet<Version> Versions { get; set; }

    public virtual DbSet<Watcher> Watchers { get; set; }

    public virtual DbSet<Wiki> Wikis { get; set; }

    public virtual DbSet<WikiContent> WikiContents { get; set; }

    public virtual DbSet<WikiContentVersion> WikiContentVersions { get; set; }

    public virtual DbSet<WikiPage> WikiPages { get; set; }

    public virtual DbSet<WikiRedirect> WikiRedirects { get; set; }

    public virtual DbSet<Workflow> Workflows { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=redmine;user id=root;password=x897ty;port=3307", ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("attachments")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AuthorId, "index_attachments_on_author_id");

            entity.HasIndex(e => new { e.ContainerId, e.ContainerType }, "index_attachments_on_container_id_and_container_type");

            entity.HasIndex(e => e.CreatedOn, "index_attachments_on_created_on");

            entity.HasIndex(e => e.DiskFilename, "index_attachments_on_disk_filename");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.ContainerId).HasColumnName("container_id");
            entity.Property(e => e.ContainerType)
                .HasMaxLength(30)
                .HasColumnName("container_type");
            entity.Property(e => e.ContentType)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("content_type");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Digest)
                .HasMaxLength(64)
                .HasDefaultValueSql("''")
                .HasColumnName("digest");
            entity.Property(e => e.DiskDirectory)
                .HasMaxLength(255)
                .HasColumnName("disk_directory");
            entity.Property(e => e.DiskFilename)
                .HasDefaultValueSql("''")
                .HasColumnName("disk_filename");
            entity.Property(e => e.Downloads).HasColumnName("downloads");
            entity.Property(e => e.Filename)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("filename");
            entity.Property(e => e.Filesize).HasColumnName("filesize");
        });

        modelBuilder.Entity<AuthSource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("auth_sources")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.Id, e.Type }, "index_auth_sources_on_id_and_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Account)
                .HasMaxLength(255)
                .HasColumnName("account");
            entity.Property(e => e.AccountPassword)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("account_password");
            entity.Property(e => e.AttrFirstname)
                .HasMaxLength(30)
                .HasColumnName("attr_firstname");
            entity.Property(e => e.AttrLastname)
                .HasMaxLength(30)
                .HasColumnName("attr_lastname");
            entity.Property(e => e.AttrLogin)
                .HasMaxLength(30)
                .HasColumnName("attr_login");
            entity.Property(e => e.AttrMail)
                .HasMaxLength(30)
                .HasColumnName("attr_mail");
            entity.Property(e => e.BaseDn)
                .HasMaxLength(255)
                .HasColumnName("base_dn");
            entity.Property(e => e.Filter)
                .HasColumnType("text")
                .HasColumnName("filter");
            entity.Property(e => e.Host)
                .HasMaxLength(60)
                .HasColumnName("host");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.OntheflyRegister).HasColumnName("onthefly_register");
            entity.Property(e => e.Port).HasColumnName("port");
            entity.Property(e => e.Timeout).HasColumnName("timeout");
            entity.Property(e => e.Tls).HasColumnName("tls");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("type");
        });

        modelBuilder.Entity<Board>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("boards")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.ProjectId, "boards_project_id");

            entity.HasIndex(e => e.LastMessageId, "index_boards_on_last_message_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.LastMessageId).HasColumnName("last_message_id");
            entity.Property(e => e.MessagesCount).HasColumnName("messages_count");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.TopicsCount).HasColumnName("topics_count");
        });

        modelBuilder.Entity<Change>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("changes")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.ChangesetId, "changesets_changeset_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .HasColumnName("action");
            entity.Property(e => e.Branch)
                .HasMaxLength(255)
                .HasColumnName("branch");
            entity.Property(e => e.ChangesetId).HasColumnName("changeset_id");
            entity.Property(e => e.FromPath)
                .HasColumnType("text")
                .HasColumnName("from_path");
            entity.Property(e => e.FromRevision)
                .HasMaxLength(255)
                .HasColumnName("from_revision");
            entity.Property(e => e.Path)
                .HasColumnType("text")
                .HasColumnName("path");
            entity.Property(e => e.Revision)
                .HasMaxLength(255)
                .HasColumnName("revision");
        });

        modelBuilder.Entity<Changeset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("changesets")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.RepositoryId, e.Revision }, "changesets_repos_rev").IsUnique();

            entity.HasIndex(e => new { e.RepositoryId, e.Scmid }, "changesets_repos_scmid");

            entity.HasIndex(e => e.CommittedOn, "index_changesets_on_committed_on");

            entity.HasIndex(e => e.RepositoryId, "index_changesets_on_repository_id");

            entity.HasIndex(e => e.UserId, "index_changesets_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.CommitDate).HasColumnName("commit_date");
            entity.Property(e => e.CommittedOn)
                .HasColumnType("datetime")
                .HasColumnName("committed_on");
            entity.Property(e => e.Committer)
                .HasMaxLength(255)
                .HasColumnName("committer");
            entity.Property(e => e.RepositoryId).HasColumnName("repository_id");
            entity.Property(e => e.Revision).HasColumnName("revision");
            entity.Property(e => e.Scmid).HasColumnName("scmid");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<ChangesetParent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("changeset_parents")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.ChangesetId, "changeset_parents_changeset_ids");

            entity.HasIndex(e => e.ParentId, "changeset_parents_parent_ids");

            entity.Property(e => e.ChangesetId).HasColumnName("changeset_id");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
        });

        modelBuilder.Entity<ChangesetsIssue>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("changesets_issues")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.ChangesetId, e.IssueId }, "changesets_issues_ids").IsUnique();

            entity.HasIndex(e => e.IssueId, "index_changesets_issues_on_issue_id");

            entity.Property(e => e.ChangesetId).HasColumnName("changeset_id");
            entity.Property(e => e.IssueId).HasColumnName("issue_id");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("comments")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AuthorId, "index_comments_on_author_id");

            entity.HasIndex(e => new { e.CommentedId, e.CommentedType }, "index_comments_on_commented_id_and_commented_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.CommentedId).HasColumnName("commented_id");
            entity.Property(e => e.CommentedType)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("commented_type");
            entity.Property(e => e.Comments)
                .HasColumnType("text")
                .HasColumnName("comments");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<CustomField>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("custom_fields")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.Id, e.Type }, "index_custom_fields_on_id_and_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DefaultValue)
                .HasColumnType("text")
                .HasColumnName("default_value");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Editable)
                .HasDefaultValueSql("'1'")
                .HasColumnName("editable");
            entity.Property(e => e.FieldFormat)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("field_format");
            entity.Property(e => e.FormatStore)
                .HasColumnType("text")
                .HasColumnName("format_store");
            entity.Property(e => e.IsFilter).HasColumnName("is_filter");
            entity.Property(e => e.IsForAll).HasColumnName("is_for_all");
            entity.Property(e => e.IsRequired).HasColumnName("is_required");
            entity.Property(e => e.MaxLength).HasColumnName("max_length");
            entity.Property(e => e.MinLength).HasColumnName("min_length");
            entity.Property(e => e.Multiple)
                .HasDefaultValueSql("'0'")
                .HasColumnName("multiple");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.PossibleValues)
                .HasColumnType("text")
                .HasColumnName("possible_values");
            entity.Property(e => e.Regexp)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("regexp");
            entity.Property(e => e.Searchable)
                .HasDefaultValueSql("'0'")
                .HasColumnName("searchable");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("type");
            entity.Property(e => e.Visible)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("visible");
        });

        modelBuilder.Entity<CustomFieldEnumeration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("custom_field_enumerations")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
            entity.Property(e => e.CustomFieldId).HasColumnName("custom_field_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Position)
                .HasDefaultValueSql("'1'")
                .HasColumnName("position");
        });

        modelBuilder.Entity<CustomFieldsProject>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("custom_fields_projects")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.CustomFieldId, e.ProjectId }, "index_custom_fields_projects_on_custom_field_id_and_project_id").IsUnique();

            entity.Property(e => e.CustomFieldId).HasColumnName("custom_field_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
        });

        modelBuilder.Entity<CustomFieldsRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("custom_fields_roles")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.CustomFieldId, e.RoleId }, "custom_fields_roles_ids").IsUnique();

            entity.Property(e => e.CustomFieldId).HasColumnName("custom_field_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
        });

        modelBuilder.Entity<CustomFieldsTracker>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("custom_fields_trackers")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.CustomFieldId, e.TrackerId }, "index_custom_fields_trackers_on_custom_field_id_and_tracker_id").IsUnique();

            entity.Property(e => e.CustomFieldId).HasColumnName("custom_field_id");
            entity.Property(e => e.TrackerId).HasColumnName("tracker_id");
        });

        modelBuilder.Entity<CustomValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("custom_values")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.CustomizedType, e.CustomizedId }, "custom_values_customized");

            entity.HasIndex(e => e.CustomFieldId, "index_custom_values_on_custom_field_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomFieldId).HasColumnName("custom_field_id");
            entity.Property(e => e.CustomizedId).HasColumnName("customized_id");
            entity.Property(e => e.CustomizedType)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("customized_type");
            entity.Property(e => e.Value)
                .HasColumnType("text")
                .HasColumnName("value");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("documents")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.ProjectId, "documents_project_id");

            entity.HasIndex(e => e.CategoryId, "index_documents_on_category_id");

            entity.HasIndex(e => e.CreatedOn, "index_documents_on_created_on");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("title");
        });

        modelBuilder.Entity<EmailAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("email_addresses")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.UserId, "index_email_addresses_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.IsDefault).HasColumnName("is_default");
            entity.Property(e => e.Notify)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("notify");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<EnabledModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("enabled_modules")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.ProjectId, "enabled_modules_project_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
        });

        modelBuilder.Entity<Enumeration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("enumerations")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.Id, e.Type }, "index_enumerations_on_id_and_type");

            entity.HasIndex(e => e.ProjectId, "index_enumerations_on_project_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
            entity.Property(e => e.IsDefault).HasColumnName("is_default");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.PositionName)
                .HasMaxLength(30)
                .HasColumnName("position_name");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<GroupsUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("groups_users")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.GroupId, e.UserId }, "groups_users_ids").IsUnique();

            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Import>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("imports")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Filename)
                .HasMaxLength(255)
                .HasColumnName("filename");
            entity.Property(e => e.Finished).HasColumnName("finished");
            entity.Property(e => e.Settings)
                .HasColumnType("text")
                .HasColumnName("settings");
            entity.Property(e => e.TotalItems).HasColumnName("total_items");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<ImportItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("import_items")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImportId).HasColumnName("import_id");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.ObjId).HasColumnName("obj_id");
            entity.Property(e => e.Position).HasColumnName("position");
        });

        modelBuilder.Entity<Issue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("issues")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AssignedToId, "index_issues_on_assigned_to_id");

            entity.HasIndex(e => e.AuthorId, "index_issues_on_author_id");

            entity.HasIndex(e => e.CategoryId, "index_issues_on_category_id");

            entity.HasIndex(e => e.CreatedOn, "index_issues_on_created_on");

            entity.HasIndex(e => e.FixedVersionId, "index_issues_on_fixed_version_id");

            entity.HasIndex(e => e.ParentId, "index_issues_on_parent_id");

            entity.HasIndex(e => e.PriorityId, "index_issues_on_priority_id");

            entity.HasIndex(e => new { e.RootId, e.Lft, e.Rgt }, "index_issues_on_root_id_and_lft_and_rgt");

            entity.HasIndex(e => e.StatusId, "index_issues_on_status_id");

            entity.HasIndex(e => e.TrackerId, "index_issues_on_tracker_id");

            entity.HasIndex(e => e.ProjectId, "issues_project_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignedToId).HasColumnName("assigned_to_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ClosedOn)
                .HasColumnType("datetime")
                .HasColumnName("closed_on");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DoneRatio).HasColumnName("done_ratio");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.EstimatedHours).HasColumnName("estimated_hours");
            entity.Property(e => e.FixedVersionId).HasColumnName("fixed_version_id");
            entity.Property(e => e.IsPrivate).HasColumnName("is_private");
            entity.Property(e => e.Lft).HasColumnName("lft");
            entity.Property(e => e.LockVersion).HasColumnName("lock_version");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Rgt).HasColumnName("rgt");
            entity.Property(e => e.RootId).HasColumnName("root_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("subject");
            entity.Property(e => e.TrackerId).HasColumnName("tracker_id");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<IssueCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("issue_categories")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AssignedToId, "index_issue_categories_on_assigned_to_id");

            entity.HasIndex(e => e.ProjectId, "issue_categories_project_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignedToId).HasColumnName("assigned_to_id");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
        });

        modelBuilder.Entity<IssueRelation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("issue_relations")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IssueFromId, "index_issue_relations_on_issue_from_id");

            entity.HasIndex(e => new { e.IssueFromId, e.IssueToId }, "index_issue_relations_on_issue_from_id_and_issue_to_id").IsUnique();

            entity.HasIndex(e => e.IssueToId, "index_issue_relations_on_issue_to_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Delay).HasColumnName("delay");
            entity.Property(e => e.IssueFromId).HasColumnName("issue_from_id");
            entity.Property(e => e.IssueToId).HasColumnName("issue_to_id");
            entity.Property(e => e.RelationType)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("relation_type");
        });

        modelBuilder.Entity<IssueStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("issue_statuses")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IsClosed, "index_issue_statuses_on_is_closed");

            entity.HasIndex(e => e.Position, "index_issue_statuses_on_position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DefaultDoneRatio).HasColumnName("default_done_ratio");
            entity.Property(e => e.IsClosed).HasColumnName("is_closed");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.Position).HasColumnName("position");
        });

        modelBuilder.Entity<Journal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("journals")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.CreatedOn, "index_journals_on_created_on");

            entity.HasIndex(e => e.JournalizedId, "index_journals_on_journalized_id");

            entity.HasIndex(e => e.UserId, "index_journals_on_user_id");

            entity.HasIndex(e => new { e.JournalizedId, e.JournalizedType }, "journals_journalized_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.JournalizedId).HasColumnName("journalized_id");
            entity.Property(e => e.JournalizedType)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("journalized_type");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.PrivateNotes).HasColumnName("private_notes");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<JournalDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("journal_details")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.JournalId, "journal_details_journal_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.JournalId).HasColumnName("journal_id");
            entity.Property(e => e.OldValue).HasColumnName("old_value");
            entity.Property(e => e.PropKey)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("prop_key");
            entity.Property(e => e.Property)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("property");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("members")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.ProjectId, "index_members_on_project_id");

            entity.HasIndex(e => e.UserId, "index_members_on_user_id");

            entity.HasIndex(e => new { e.UserId, e.ProjectId }, "index_members_on_user_id_and_project_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.MailNotification).HasColumnName("mail_notification");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<MemberRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("member_roles")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.InheritedFrom, "index_member_roles_on_inherited_from");

            entity.HasIndex(e => e.MemberId, "index_member_roles_on_member_id");

            entity.HasIndex(e => e.RoleId, "index_member_roles_on_role_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.InheritedFrom).HasColumnName("inherited_from");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("messages")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AuthorId, "index_messages_on_author_id");

            entity.HasIndex(e => e.CreatedOn, "index_messages_on_created_on");

            entity.HasIndex(e => e.LastReplyId, "index_messages_on_last_reply_id");

            entity.HasIndex(e => e.BoardId, "messages_board_id");

            entity.HasIndex(e => e.ParentId, "messages_parent_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BoardId).HasColumnName("board_id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.LastReplyId).HasColumnName("last_reply_id");
            entity.Property(e => e.Locked)
                .HasDefaultValueSql("'0'")
                .HasColumnName("locked");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.RepliesCount).HasColumnName("replies_count");
            entity.Property(e => e.Sticky)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sticky");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("subject");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("news")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AuthorId, "index_news_on_author_id");

            entity.HasIndex(e => e.CreatedOn, "index_news_on_created_on");

            entity.HasIndex(e => e.ProjectId, "news_project_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.CommentsCount).HasColumnName("comments_count");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Summary)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("summary");
            entity.Property(e => e.Title)
                .HasMaxLength(60)
                .HasDefaultValueSql("''")
                .HasColumnName("title");
        });

        modelBuilder.Entity<OpenIdAuthenticationAssociation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("open_id_authentication_associations")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssocType)
                .HasMaxLength(255)
                .HasColumnName("assoc_type");
            entity.Property(e => e.Handle)
                .HasMaxLength(255)
                .HasColumnName("handle");
            entity.Property(e => e.Issued).HasColumnName("issued");
            entity.Property(e => e.Lifetime).HasColumnName("lifetime");
            entity.Property(e => e.Secret)
                .HasColumnType("blob")
                .HasColumnName("secret");
            entity.Property(e => e.ServerUrl)
                .HasColumnType("blob")
                .HasColumnName("server_url");
        });

        modelBuilder.Entity<OpenIdAuthenticationNonce>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("open_id_authentication_nonces")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Salt)
                .HasMaxLength(255)
                .HasColumnName("salt");
            entity.Property(e => e.ServerUrl)
                .HasMaxLength(255)
                .HasColumnName("server_url");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("projects")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Lft, "index_projects_on_lft");

            entity.HasIndex(e => e.Rgt, "index_projects_on_rgt");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DefaultAssignedToId).HasColumnName("default_assigned_to_id");
            entity.Property(e => e.DefaultVersionId).HasColumnName("default_version_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Homepage)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("homepage");
            entity.Property(e => e.Identifier)
                .HasMaxLength(255)
                .HasColumnName("identifier");
            entity.Property(e => e.InheritMembers).HasColumnName("inherit_members");
            entity.Property(e => e.IsPublic)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_public");
            entity.Property(e => e.Lft).HasColumnName("lft");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Rgt).HasColumnName("rgt");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<ProjectsTracker>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("projects_trackers")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.ProjectId, "projects_trackers_project_id");

            entity.HasIndex(e => new { e.ProjectId, e.TrackerId }, "projects_trackers_unique").IsUnique();

            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.TrackerId).HasColumnName("tracker_id");
        });

        modelBuilder.Entity<QueriesRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("queries_roles")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.QueryId, e.RoleId }, "queries_roles_ids").IsUnique();

            entity.Property(e => e.QueryId).HasColumnName("query_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
        });

        modelBuilder.Entity<Query>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("queries")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.ProjectId, "index_queries_on_project_id");

            entity.HasIndex(e => e.UserId, "index_queries_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ColumnNames)
                .HasColumnType("text")
                .HasColumnName("column_names");
            entity.Property(e => e.Filters)
                .HasColumnType("text")
                .HasColumnName("filters");
            entity.Property(e => e.GroupBy)
                .HasMaxLength(255)
                .HasColumnName("group_by");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.Options)
                .HasColumnType("text")
                .HasColumnName("options");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.SortCriteria)
                .HasColumnType("text")
                .HasColumnName("sort_criteria");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Visibility)
                .HasDefaultValueSql("'0'")
                .HasColumnName("visibility");
        });

        modelBuilder.Entity<Repository>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("repositories")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.ProjectId, "index_repositories_on_project_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.ExtraInfo).HasColumnName("extra_info");
            entity.Property(e => e.Identifier)
                .HasMaxLength(255)
                .HasColumnName("identifier");
            entity.Property(e => e.IsDefault)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_default");
            entity.Property(e => e.LogEncoding)
                .HasMaxLength(64)
                .HasColumnName("log_encoding");
            entity.Property(e => e.Login)
                .HasMaxLength(60)
                .HasDefaultValueSql("''")
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("password");
            entity.Property(e => e.PathEncoding)
                .HasMaxLength(64)
                .HasColumnName("path_encoding");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.RootUrl)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("root_url");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("url");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("roles")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllRolesManaged)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("all_roles_managed");
            entity.Property(e => e.Assignable)
                .HasDefaultValueSql("'1'")
                .HasColumnName("assignable");
            entity.Property(e => e.Builtin).HasColumnName("builtin");
            entity.Property(e => e.IssuesVisibility)
                .HasMaxLength(30)
                .HasDefaultValueSql("'default'")
                .HasColumnName("issues_visibility");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.Permissions)
                .HasColumnType("text")
                .HasColumnName("permissions");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Settings)
                .HasColumnType("text")
                .HasColumnName("settings");
            entity.Property(e => e.TimeEntriesVisibility)
                .HasMaxLength(30)
                .HasDefaultValueSql("'all'")
                .HasColumnName("time_entries_visibility");
            entity.Property(e => e.UsersVisibility)
                .HasMaxLength(30)
                .HasDefaultValueSql("'all'")
                .HasColumnName("users_visibility");
        });

        modelBuilder.Entity<RolesManagedRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("roles_managed_roles")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.RoleId, e.ManagedRoleId }, "index_roles_managed_roles_on_role_id_and_managed_role_id").IsUnique();

            entity.Property(e => e.ManagedRoleId).HasColumnName("managed_role_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
        });

        modelBuilder.Entity<SchemaMigration>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("schema_migrations")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Version, "unique_schema_migrations").IsUnique();

            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("settings")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Name, "index_settings_on_name");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
            entity.Property(e => e.Value)
                .HasColumnType("text")
                .HasColumnName("value");
        });

        modelBuilder.Entity<TimeEntry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("time_entries")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.ActivityId, "index_time_entries_on_activity_id");

            entity.HasIndex(e => e.CreatedOn, "index_time_entries_on_created_on");

            entity.HasIndex(e => e.UserId, "index_time_entries_on_user_id");

            entity.HasIndex(e => e.IssueId, "time_entries_issue_id");

            entity.HasIndex(e => e.ProjectId, "time_entries_project_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.Comments)
                .HasMaxLength(1024)
                .HasColumnName("comments");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Hours).HasColumnName("hours");
            entity.Property(e => e.IssueId).HasColumnName("issue_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.SpentOn).HasColumnName("spent_on");
            entity.Property(e => e.Tmonth).HasColumnName("tmonth");
            entity.Property(e => e.Tweek).HasColumnName("tweek");
            entity.Property(e => e.Tyear).HasColumnName("tyear");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tokens")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.UserId, "index_tokens_on_user_id");

            entity.HasIndex(e => e.Value, "tokens_value").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("action");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Value)
                .HasMaxLength(40)
                .HasDefaultValueSql("''")
                .HasColumnName("value");
        });

        modelBuilder.Entity<Tracker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("trackers")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DefaultStatusId).HasColumnName("default_status_id");
            entity.Property(e => e.FieldsBits)
                .HasDefaultValueSql("'0'")
                .HasColumnName("fields_bits");
            entity.Property(e => e.IsInChlog).HasColumnName("is_in_chlog");
            entity.Property(e => e.IsInRoadmap)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_in_roadmap");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.Position).HasColumnName("position");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("users")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AuthSourceId, "index_users_on_auth_source_id");

            entity.HasIndex(e => new { e.Id, e.Type }, "index_users_on_id_and_type");

            entity.HasIndex(e => e.Type, "index_users_on_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Admin).HasColumnName("admin");
            entity.Property(e => e.AuthSourceId).HasColumnName("auth_source_id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Firstname)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("firstname");
            entity.Property(e => e.HashedPassword)
                .HasMaxLength(40)
                .HasDefaultValueSql("''")
                .HasColumnName("hashed_password");
            entity.Property(e => e.IdentityUrl)
                .HasMaxLength(255)
                .HasColumnName("identity_url");
            entity.Property(e => e.Language)
                .HasMaxLength(5)
                .HasDefaultValueSql("''")
                .HasColumnName("language");
            entity.Property(e => e.LastLoginOn)
                .HasColumnType("datetime")
                .HasColumnName("last_login_on");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("lastname");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("login");
            entity.Property(e => e.MailNotification)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("mail_notification");
            entity.Property(e => e.MustChangePasswd).HasColumnName("must_change_passwd");
            entity.Property(e => e.PasswdChangedOn)
                .HasColumnType("datetime")
                .HasColumnName("passwd_changed_on");
            entity.Property(e => e.Salt)
                .HasMaxLength(64)
                .HasColumnName("salt");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<UserPreference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_preferences")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.UserId, "index_user_preferences_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HideMail)
                .HasDefaultValueSql("'1'")
                .HasColumnName("hide_mail");
            entity.Property(e => e.Others)
                .HasColumnType("text")
                .HasColumnName("others");
            entity.Property(e => e.TimeZone)
                .HasMaxLength(255)
                .HasColumnName("time_zone");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Entities.Version>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("versions")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Sharing, "index_versions_on_sharing");

            entity.HasIndex(e => e.ProjectId, "versions_project_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.EffectiveDate).HasColumnName("effective_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Sharing)
                .HasDefaultValueSql("'none'")
                .HasColumnName("sharing");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasDefaultValueSql("'open'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
            entity.Property(e => e.WikiPageTitle)
                .HasMaxLength(255)
                .HasColumnName("wiki_page_title");
        });

        modelBuilder.Entity<Watcher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("watchers")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.UserId, "index_watchers_on_user_id");

            entity.HasIndex(e => new { e.WatchableId, e.WatchableType }, "index_watchers_on_watchable_id_and_watchable_type");

            entity.HasIndex(e => new { e.UserId, e.WatchableType }, "watchers_user_id_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WatchableId).HasColumnName("watchable_id");
            entity.Property(e => e.WatchableType)
                .HasDefaultValueSql("''")
                .HasColumnName("watchable_type");
        });

        modelBuilder.Entity<Wiki>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("wikis")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.ProjectId, "wikis_project_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.StartPage)
                .HasMaxLength(255)
                .HasColumnName("start_page");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
        });

        modelBuilder.Entity<WikiContent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("wiki_contents")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AuthorId, "index_wiki_contents_on_author_id");

            entity.HasIndex(e => e.PageId, "wiki_contents_page_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Comments)
                .HasMaxLength(1024)
                .HasDefaultValueSql("''")
                .HasColumnName("comments");
            entity.Property(e => e.PageId).HasColumnName("page_id");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<WikiContentVersion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("wiki_content_versions")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.UpdatedOn, "index_wiki_content_versions_on_updated_on");

            entity.HasIndex(e => e.WikiContentId, "wiki_content_versions_wcid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Comments)
                .HasMaxLength(1024)
                .HasDefaultValueSql("''")
                .HasColumnName("comments");
            entity.Property(e => e.Compression)
                .HasMaxLength(6)
                .HasDefaultValueSql("''")
                .HasColumnName("compression");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.PageId).HasColumnName("page_id");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
            entity.Property(e => e.Version).HasColumnName("version");
            entity.Property(e => e.WikiContentId).HasColumnName("wiki_content_id");
        });

        modelBuilder.Entity<WikiPage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("wiki_pages")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.ParentId, "index_wiki_pages_on_parent_id");

            entity.HasIndex(e => e.WikiId, "index_wiki_pages_on_wiki_id");

            entity.HasIndex(e => new { e.WikiId, e.Title }, "wiki_pages_wiki_id_title");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Protected).HasColumnName("protected");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.WikiId).HasColumnName("wiki_id");
        });

        modelBuilder.Entity<WikiRedirect>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("wiki_redirects")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.WikiId, "index_wiki_redirects_on_wiki_id");

            entity.HasIndex(e => new { e.WikiId, e.Title }, "wiki_redirects_wiki_id_title");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.RedirectsTo)
                .HasMaxLength(255)
                .HasColumnName("redirects_to");
            entity.Property(e => e.RedirectsToWikiId).HasColumnName("redirects_to_wiki_id");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.WikiId).HasColumnName("wiki_id");
        });

        modelBuilder.Entity<Workflow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("workflows")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.NewStatusId, "index_workflows_on_new_status_id");

            entity.HasIndex(e => e.OldStatusId, "index_workflows_on_old_status_id");

            entity.HasIndex(e => e.RoleId, "index_workflows_on_role_id");

            entity.HasIndex(e => e.TrackerId, "index_workflows_on_tracker_id");

            entity.HasIndex(e => new { e.RoleId, e.TrackerId, e.OldStatusId }, "wkfs_role_tracker_old_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Assignee).HasColumnName("assignee");
            entity.Property(e => e.Author).HasColumnName("author");
            entity.Property(e => e.FieldName)
                .HasMaxLength(30)
                .HasColumnName("field_name");
            entity.Property(e => e.NewStatusId).HasColumnName("new_status_id");
            entity.Property(e => e.OldStatusId).HasColumnName("old_status_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Rule)
                .HasMaxLength(30)
                .HasColumnName("rule");
            entity.Property(e => e.TrackerId).HasColumnName("tracker_id");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
