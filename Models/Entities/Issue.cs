using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("issues")]
    public class Issue
    {
        [Key]
        public int id { get; set; }
        public int tracker_id { get; set; }
        public int project_id { get; set; }
        public string subject { get; set; }
        public string? description { get; set; }
        public DateTime? due_date { get; set; }
        public int? category_id { get; set; }
        public int status_id { get; set; }
        public int? assigned_to_id { get; set; }
        public int priority_id { get; set; }
        public int? fixed_version_id { get; set; }
        public int author_id { get; set; }
        public int lock_version { get; set; }
        public DateTime? created_on { get; set; }
        public DateTime? updated_on { get; set; }
        public DateTime? start_date { get; set; }
        public int done_ratio { get; set; }
        public float? estimated_hours { get; set; }
        public int? parent_id { get; set; }
        public int? root_id { get; set; }
        public int? lft { get; set; }
        public int? rgt { get; set; }
        public byte is_private { get; set; }
        public DateTime? closed_on { get; set; }
    }
}
