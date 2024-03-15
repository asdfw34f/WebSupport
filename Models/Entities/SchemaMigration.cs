using System;
using System.Collections.Generic;

namespace WebSupport.Models.Entities;

public partial class SchemaMigration
{
    public string Version { get; set; } = null!;
}
