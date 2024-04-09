namespace WebSupport.DataEntities;

public partial class Watcher
{
    public int Id { get; set; }

    public string WatchableType { get; set; } = null!;

    public int WatchableId { get; set; }

    public int? UserId { get; set; }
}
