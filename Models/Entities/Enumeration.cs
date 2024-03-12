using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name: "enumerations")]
    public class Enumeration
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int position { get; set; }
        public byte is_default { get; set; }
        public string type { get; set; }
        public byte active { get; set; }
        public int project_id { get; set; }
        public int parent_id { get; set; }
        public string position_name { get; set; }
    }
}
