using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name:"changesets")]
    public class Changeset
    {
        [Key]
        public int id { get; set; }
        public int repository_id { get; set; }
        public string? revision { get; set; }
        public string? committer { get; set; }
        public DateTime? committed_on { get; set; }
        public string? comments { get; set; }
        public DateOnly? commit_date { get; set; }
        public string? scmid { get; set; }
        public int user_id { get; set; }
    }
}
