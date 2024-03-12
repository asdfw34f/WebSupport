using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebSupport.Models.Entities
{
    [Table(name: "custom_fields")]
    public class CustomField
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? field_format { get; set; }
        public string? possible_values { get; set; }
        public string? regexp { get; set; }
        public int min_length { get; set; }
        public int max_length { get; set; }
        public byte is_required { get; set; }
        public byte is_for_all { get; set; }
        public byte is_filter { get; set; }
        public int position { get; set; }
        public byte searchable { get; set; }
        public string? default_value { get; set; }
        public byte editable { get; set; }
        public byte visible { get; set; }
        public byte multiple { get; set; }
        public string format_store { get; set; }
        public string description { get; set; }
    }
}