using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name:"changeset_parent")]
    public class ChangesetParent
    {
        [Key]
        public int chaneset_id { get; set; }
        public int parent_id { get; set; }
    }
}
