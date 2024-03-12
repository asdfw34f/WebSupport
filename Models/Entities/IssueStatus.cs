using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("issue_statuses")]
    public class IssueStatus
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public byte is_closed { get; set; }
        public int? position { get; set; }
        public int? default_done_ratio { get; set; }
    }
}
