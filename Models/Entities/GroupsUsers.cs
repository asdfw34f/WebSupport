using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("groups_users")]
    public class GroupsUsers
    {
        [Key]
        public int group_id { get; set; }
        public int user_id { get; set; }
    }
}
