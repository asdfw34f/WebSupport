using System;
using System.Collections.Generic;

namespace WebSupport.Models.Entities;

public partial class JournalDetail
{
    public int Id { get; set; }

    public int JournalId { get; set; }

    public string Property { get; set; } = null!;

    public string PropKey { get; set; } = null!;

    public string? OldValue { get; set; }

    public string? Value { get; set; }
}
