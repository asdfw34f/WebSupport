using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("issue_categories")]
    public class IssueCategory
    {
        [Key]
        public int id { get; set; }
        public int project_id { get; set; }
        public string name { get; set; }
        public int? assigned_to_id { get; set; }
    }
}

