using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("imports")]
    public class Import
    {
        [Key]
        public int id { get; set; }
        public string? type { get; set; }
        public int user_id { get; set; }
        public string? filename { get; set; }
        public string? settings { get; set; }
        public int? total_items { get; set; }
        public byte finished { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
