using System;
using System.Collections.Generic;

namespace WebSupport.DataEntities;

public partial class Enumeration
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Position { get; set; }

    public bool IsDefault { get; set; }

    public string? Type { get; set; }

    public bool? Active { get; set; }

    public int? ProjectId { get; set; }

    public int? ParentId { get; set; }

    public string? PositionName { get; set; }
}
