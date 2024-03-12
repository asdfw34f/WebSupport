using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name: "custom_fields_roles")]
    public class CustomFieldsRole
    {
        [Key]
        public int custom_field_id { get; set; }
        public int role_id {get;set;}
    }
}
