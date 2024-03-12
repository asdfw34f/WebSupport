using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("members")]
    public class Member
    {
        [Key] 
        public int id { get; set; }
        public int user_id { get; set; }
        public int project_id { get; set; }
        public DateTime? created_on { get; set; }
        public byte mail_notification { get; set; }
    }
}
