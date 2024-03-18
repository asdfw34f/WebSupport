using System;
using System.Collections.Generic;

namespace WebSupport.Entities;

public partial class OpenIdAuthenticationNonce
{
    public int Id { get; set; }

    public int Timestamp { get; set; }

    public string? ServerUrl { get; set; }

    public string Salt { get; set; } = null!;
}
