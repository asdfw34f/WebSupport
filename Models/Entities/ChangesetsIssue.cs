using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name:"changesets_issues")]
    public class ChangesetsIssue
    {
        [Key]
        public int changeset_id { get; set; }
        public int isuue_id { get; set; }
    }
}
