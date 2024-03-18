using System;
using System.Collections.Generic;

namespace WebSupport.Entities;

public partial class Token
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Action { get; set; } = null!;

    public string Value { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
