namespace WebSupport.DataEntities;

public partial class Journal
{
    public int Id { get; set; }

    public int JournalizedId { get; set; }

    public string JournalizedType { get; set; } = null!;

    public int UserId { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedOn { get; set; }

    public bool PrivateNotes { get; set; }
}
