using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("projects")]
    public class Project
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string? description { get; set; }
        public string? homepage { get; set; }
        public byte is_public { get; set; }
        public int? parent_id { get; set; }
        public DateTime? created_on { get; set; }
        public DateTime? updated_on { get; set; }
        public string? identifier { get; set; }
        public int status { get; set; }
        public int? lft { get; set; }
        public int? rgt { get; set; }
        public byte inherit_members { get; set; }
        public int? default_version_id { get; set; }
        public int? default_assigned_to_id { get; set; }
    }
}
