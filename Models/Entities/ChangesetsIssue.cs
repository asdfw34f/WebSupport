using System;
using System.Collections.Generic;

namespace WebSupport.Models.Entities;

public partial class ChangesetsIssue
{
    public int ChangesetId { get; set; }

    public int IssueId { get; set; }
}
