using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("projects_trackers")]
    public class ProjectTracker
    {
        [Key]
        public int project_id { get; set; }
        public int tracker_id { get; set; }
    }
}
