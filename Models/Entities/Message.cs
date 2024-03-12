using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("messages")]
    public class Message
    {
        [Key] 
        public int id { get; set; }
        public int board_id { get; set; }
        public int? parent_id { get; set; }
        public string subject { get; set; }
        public string? content { get; set; }
        public int? author_id { get; set; }
        public int replies_count { get; set; }
        public int? last_reply_id { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }
        public byte? locked { get; set; }
        public int? sticky { get; set; }
    }
}
