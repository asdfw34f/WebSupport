using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("issue_relations")]
    public class IssueRelation
    {
        [Key]
        public int id { get; set; }
        public int issue_from_id { get; set; }
        public int issue_to_id { get; set; }
        public string relation_type { get; set; }
        public int? delay { get; set; }
    }
}
