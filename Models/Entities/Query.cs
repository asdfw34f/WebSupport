using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("queries")]
    public class Query
    {
        [Key]
        public int id { get; set; }
        public int? project_id { get; set; }
        public string name { get; set; }
        public string? filters { get; set; }
        public int user_id { get; set; }
        public string? column_names { get; set; }
        public string? sort_criteria { get; set; }
        public string? group_by { get; set; }
        public string? type { get; set; }
        public int? visibility { get; set; }
        public string? options { get; set; }
    }
}
