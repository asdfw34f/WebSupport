using System.ComponentModel.DataAnnotations.Schema;
using WebSupport.DataEntities;

namespace WebSupport.Models.ViewModels
{
    public class TrackerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int projectId { get; set; }
        [ForeignKey("projectId")]
        public Project project { get; set; }
    }
}
