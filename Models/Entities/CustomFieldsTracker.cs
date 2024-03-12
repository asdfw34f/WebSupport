using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name: "custom_fields_trackers")]
    public class CustomFieldsTracker
    {
        [Key]
        public int custom_field_id { get; set; }
        public int tracker_id { get; set;}
    }
}
