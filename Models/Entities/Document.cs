﻿using System;
using System.Collections.Generic;

namespace WebSupport.Models.Entities;

public partial class Document
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedOn { get; set; }
}
