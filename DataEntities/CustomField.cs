﻿namespace WebSupport.DataEntities;

public partial class CustomField
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string FieldFormat { get; set; } = null!;

    public string? PossibleValues { get; set; }

    public string? Regexp { get; set; }

    public int? MinLength { get; set; }

    public int? MaxLength { get; set; }

    public bool IsRequired { get; set; }

    public bool IsForAll { get; set; }

    public bool IsFilter { get; set; }

    public int? Position { get; set; }

    public bool? Searchable { get; set; }

    public string? DefaultValue { get; set; }

    public bool? Editable { get; set; }

    public bool? Visible { get; set; }

    public bool? Multiple { get; set; }

    public string? FormatStore { get; set; }

    public string? Description { get; set; }
}
