using System;
using System.Collections.Generic;

namespace WebSupport.DataEntities;

public partial class AuthSource
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Host { get; set; }

    public int? Port { get; set; }

    public string? Account { get; set; }

    public string? AccountPassword { get; set; }

    public string? BaseDn { get; set; }

    public string? AttrLogin { get; set; }

    public string? AttrFirstname { get; set; }

    public string? AttrLastname { get; set; }

    public string? AttrMail { get; set; }

    public bool OntheflyRegister { get; set; }

    public bool Tls { get; set; }

    public string? Filter { get; set; }

    public int? Timeout { get; set; }

    public bool? VerifyPeer { get; set; }
}
