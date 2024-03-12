using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name:"comments")]
    public class Comment
    {
        [Key]
        public int id { get; set; }
        public string? commented_type { get; set; }
        public int commented_id { get; set; }
        public int author_id { get; set; }
        public string? comments { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set;}
    }
}
