using System;
using System.Collections.Generic;

namespace WebSupport.DataEntities;

public partial class Member
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ProjectId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public bool MailNotification { get; set; }
}
