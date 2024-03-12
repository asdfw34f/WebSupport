using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name: "boards")]
    public class Board
    {
        [Key]
        public int id { get; set; }
        public int project_id { get; set; }
        public string? description { get; set; }
        public string? name { get; set; }
        public int position { get; set; }
        public int topics_count { get; set; }
        public int messages_count { get; set; }
        public int last_message_id { get; set; }
        public int parent_id { get; set; }

    }
}
