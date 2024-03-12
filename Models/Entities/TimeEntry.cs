using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("time_entries")]
    public class TimeEntry
    {
        [Key]
        public int id { get; set; }
        public int project_id { get; set; }
        public int user_id { get; set; }
        public int? issue_id { get; set; }
        public float hours { get; set; }
        public string? comments { get; set; }
        public int activity_id { get; set; }
        public DateTime spent_on { get; set; }
        public int tyear { get; set; }
        public int tmonth { get; set; }
        public int tweek { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }
    }
}
