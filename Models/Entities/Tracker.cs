using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("trackers")]
    public class Tracker
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public byte is_in_chlog { get; set; }
        public int? position { get; set; }
        public byte is_in_roadmap { get; set; }
        public int? fields_bits { get; set; }
        public int? default_status_id { get; set; }
    }
}
