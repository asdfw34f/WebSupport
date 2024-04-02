using System;
using System.Collections.Generic;

namespace WebSupport.DataEntities;

public partial class SchemaMigration
{
    public string Version { get; set; } = null!;
}
