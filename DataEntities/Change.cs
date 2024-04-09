namespace WebSupport.DataEntities;

public partial class Change
{
    public int Id { get; set; }

    public int ChangesetId { get; set; }

    public string Action { get; set; } = null!;

    public string Path { get; set; } = null!;

    public string? FromPath { get; set; }

    public string? FromRevision { get; set; }

    public string? Revision { get; set; }

    public string? Branch { get; set; }
}
