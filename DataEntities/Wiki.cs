namespace WebSupport.DataEntities;

public partial class Wiki
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public string StartPage { get; set; } = null!;

    public int Status { get; set; }
}
