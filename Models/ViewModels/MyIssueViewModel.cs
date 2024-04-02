using WebSupport.Data;
using WebSupport.DataEntities;

namespace WebSupport.Models.ViewModels
{
    public class MyIssueViewModel
    {
        RedmineContext context;
        public List<IssueViewModel> issues { get; set; } = new List<IssueViewModel>();

        public List<IssueStatus> Statuses { get; set; }

        public MyIssueViewModel(RedmineContext context)
        {
            this.context = context;
        }
    }
}
