using System;
using System.Collections.Generic;

namespace WebSupport.Models.Entities;

public partial class GroupsUser
{
    public int GroupId { get; set; }

    public int UserId { get; set; }
}
