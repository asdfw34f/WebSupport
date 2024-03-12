using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name: "custom_field_enumerations")]
    public class CustomFieldEnumeration
    {
        [Key]
        public int id { get; set; }
        public int custom_field_id { get; set; }
        public string? name { get; set; }
        public byte active { get; set; }
        public int position { get; set; }
    }
}