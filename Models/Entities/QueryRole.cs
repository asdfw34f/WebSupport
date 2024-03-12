using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("queries_roles")]
    public class QueryRole
    {
        [Key]
        public int query_id { get; set; }
        public int role_id { get; set; }
    }
}