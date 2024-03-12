using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("journal_details")]
    public class JournalDetail
    {
        [Key]
        public int id { get; set; }
        public int journal_id { get; set; }
        public string property { get; set; }
        public string prop_key { get; set; }
        public string? old_value { get; set; }
        public string? value { get; set; }
    }
}
