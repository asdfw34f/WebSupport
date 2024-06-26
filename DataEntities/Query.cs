﻿namespace WebSupport.DataEntities;

public partial class Query
{
    public int Id { get; set; }

    public int? ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public string? Filters { get; set; }

    public int UserId { get; set; }

    public string? ColumnNames { get; set; }

    public string? SortCriteria { get; set; }

    public string? GroupBy { get; set; }

    public string? Type { get; set; }

    public int? Visibility { get; set; }

    public string? Options { get; set; }
}
