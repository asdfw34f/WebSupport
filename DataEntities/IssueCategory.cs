namespace WebSupport.DataEntities;

public partial class IssueCategory
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public int? AssignedToId { get; set; }
}
