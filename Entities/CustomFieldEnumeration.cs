using System;
using System.Collections.Generic;

namespace WebSupport.Entities;

public partial class CustomFieldEnumeration
{
    public int Id { get; set; }

    public int CustomFieldId { get; set; }

    public string Name { get; set; } = null!;

    public bool? Active { get; set; }

    public int Position { get; set; }
}
