using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name: "email_addresses")]
    public class EmailAddress
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public string? address { get; set; }
        public byte is_default { get; set; }
        public byte notify { get; set; }
        public DateTime? created_on { get; set; }
        public DateTime? updated_on { get; set; }
    }
}
