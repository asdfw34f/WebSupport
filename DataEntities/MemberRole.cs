﻿namespace WebSupport.DataEntities;

public partial class MemberRole
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int RoleId { get; set; }

    public int? InheritedFrom { get; set; }
}
