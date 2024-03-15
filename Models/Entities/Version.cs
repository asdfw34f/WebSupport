using System;
using System.Collections.Generic;

namespace WebSupport.Models.Entities;

public partial class Version
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? EffectiveDate { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? WikiPageTitle { get; set; }

    public string? Status { get; set; }

    public string Sharing { get; set; } = null!;
}
