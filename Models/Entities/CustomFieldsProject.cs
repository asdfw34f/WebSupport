using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name: "custom_fields_projects")]
    public class CustomFieldsProject
    {
        [Key]
        public int custom_field_id { get; set; }
        public int project_id { get; set; }

    }
}
