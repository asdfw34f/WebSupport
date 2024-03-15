﻿using System;
using System.Collections.Generic;

namespace WebSupport.Models.Entities;

public partial class Setting
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Value { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
