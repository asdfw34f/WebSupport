using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("news")]
    public class New
    {
        [Key]
        public int id { get; set; }
        public int? project_id { get; set; }
        public string title { get; set; }
        public string? summary { get; set; }
        public string? description { get; set; }
        public int author_id { get; set; }
        public DateTime? created_on { get; set; }
        public int comments_count { get; set; }
    }
}
