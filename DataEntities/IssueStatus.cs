using System;
using System.Collections.Generic;

namespace WebSupport.DataEntities;

public partial class IssueStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsClosed { get; set; }

    public int? Position { get; set; }

    public int? DefaultDoneRatio { get; set; }
}
