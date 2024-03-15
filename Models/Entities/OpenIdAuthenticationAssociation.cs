using System;
using System.Collections.Generic;

namespace WebSupport.Models.Entities;

public partial class OpenIdAuthenticationAssociation
{
    public int Id { get; set; }

    public int? Issued { get; set; }

    public int? Lifetime { get; set; }

    public string? Handle { get; set; }

    public string? AssocType { get; set; }

    public byte[]? ServerUrl { get; set; }

    public byte[]? Secret { get; set; }
}
