using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("tokens")]
    public class Token
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public string action { get; set; }
        public string value { get; set; }
        public DateTime created_on { get; set; }
        public DateTime? updated_on { get; set; }
    }
}
