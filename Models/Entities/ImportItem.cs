using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("import_items")]
    public class ImportItem
    {
        [Key]
        public int id { get; set; }
        public int import_id { get; set; }
        public int position { get; set; }
        public int? obj_id { get; set; }
        public string? message { get; set; }
    }
}
