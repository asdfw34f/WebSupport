using System;
using System.Collections.Generic;

namespace WebSupport.DataEntities;

public partial class Attachment
{
    public int Id { get; set; }

    public int? ContainerId { get; set; }

    public string? ContainerType { get; set; }

    public string Filename { get; set; } = null!;

    public string DiskFilename { get; set; } = null!;

    public long Filesize { get; set; }

    public string? ContentType { get; set; }

    public string Digest { get; set; } = null!;

    public int Downloads { get; set; }

    public int AuthorId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? Description { get; set; }

    public string? DiskDirectory { get; set; }
}
