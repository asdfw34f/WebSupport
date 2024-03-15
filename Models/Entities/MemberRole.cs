using System;
using System.Collections.Generic;

namespace WebSupport.Models.Entities;

public partial class MemberRole
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int RoleId { get; set; }

    public int? InheritedFrom { get; set; }
}
