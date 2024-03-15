using System;
using System.Collections.Generic;

namespace WebSupport.Models.Entities;

public partial class ChangesetParent
{
    public int ChangesetId { get; set; }

    public int ParentId { get; set; }
}
