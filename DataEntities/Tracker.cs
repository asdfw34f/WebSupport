using System;
using System.Collections.Generic;

namespace WebSupport.DataEntities;

public partial class Tracker
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? Position { get; set; }

    public bool? IsInRoadmap { get; set; }

    public int? FieldsBits { get; set; }

    public int? DefaultStatusId { get; set; }
}
