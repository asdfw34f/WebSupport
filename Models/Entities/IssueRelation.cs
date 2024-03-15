using System;
using System.Collections.Generic;

namespace WebSupport.Models.Entities;

public partial class IssueRelation
{
    public int Id { get; set; }

    public int IssueFromId { get; set; }

    public int IssueToId { get; set; }

    public string RelationType { get; set; } = null!;

    public int? Delay { get; set; }
}
