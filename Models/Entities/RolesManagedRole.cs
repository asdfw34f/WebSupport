﻿using System;
using System.Collections.Generic;

namespace WebSupport.Models.Entities;

public partial class RolesManagedRole
{
    public int RoleId { get; set; }

    public int ManagedRoleId { get; set; }
}