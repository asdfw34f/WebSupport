using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name: "documents")]
    public class Document
    {
        [Key]
        public int id { get; set; }
        public int project_id { get; set; }
        public int category_id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public DateTime? created_on { get; set; }
    }
}
