using System;
using System.Collections.Generic;

namespace WebSupport.Models.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public string CommentedType { get; set; } = null!;

    public int CommentedId { get; set; }

    public int AuthorId { get; set; }

    public string? Comments { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }
}
