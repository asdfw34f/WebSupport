using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name: "custom_values")]
    public class CustomValue
    {
        [Key]
        public int id { get; set; }
        public string? customized_type { get; set; }
        public int customized_id { get; set; }
        public int customized_field_id { get; set; }
        public string? value { get; set; }
    }
}
