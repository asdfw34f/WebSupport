using WebSupport.DataEntities;

namespace WebSupport.Models.ViewModels
{
    public class AddIssueViewModel
    {
        public Tracker tracker { get; set; }
        public int projectID { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
    }
}
