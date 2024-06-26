﻿namespace WebSupport.DataEntities;

public partial class CustomValue
{
    public int Id { get; set; }

    public string CustomizedType { get; set; } = null!;

    public int CustomizedId { get; set; }

    public int CustomFieldId { get; set; }

    public string? Value { get; set; }
}
