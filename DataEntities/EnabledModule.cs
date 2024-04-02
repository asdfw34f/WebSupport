using System;
using System.Collections.Generic;

namespace WebSupport.DataEntities;

public partial class EnabledModule
{
    public int Id { get; set; }

    public int? ProjectId { get; set; }

    public string Name { get; set; } = null!;
}
