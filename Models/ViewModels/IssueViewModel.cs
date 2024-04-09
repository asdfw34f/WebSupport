using WebSupport.DataEntities;

namespace WebSupport.Models.ViewModels
{
    public class IssueViewModel
    {
        public Issue issue { get; set; }

        public string ProjectName { get; set; }
        public string TrackerName { get; set; }

        public string AuthorName { get; set; }

        public string status { get; set; }



        public IssueViewModel(Issue issue, string projectName, string trackerName, string authorName, string status = "")
        {
            this.issue = issue;
            ProjectName = projectName;
            TrackerName = trackerName;
            AuthorName = authorName;
            this.status = status;

        }


    }
}
