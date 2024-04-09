namespace WebSupport.DataEntities;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public bool Admin { get; set; }

    public int Status { get; set; }

    public DateTime? LastLoginOn { get; set; }

    public string? Language { get; set; }

    public int? AuthSourceId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Type { get; set; }

    public string MailNotification { get; set; } = null!;

    public string? Salt { get; set; }

    public bool MustChangePasswd { get; set; }

    public DateTime? PasswdChangedOn { get; set; }

    public string? TwofaScheme { get; set; }

    public string? TwofaTotpKey { get; set; }

    public int? TwofaTotpLastUsedAt { get; set; }

    public bool? TwofaRequired { get; set; }
}
