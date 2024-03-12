using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("member_roles")]
    public class MemberRole
    {
        [Key]
        public int id { get; set; }
        public int member_id { get; set; }
        public int role_id { get; set; }
        public int? inherited_from { get; set; }
    }
}