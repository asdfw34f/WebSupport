using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table("roles")]
    public class Role
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int? position { get; set; }
        public byte? assignable { get; set; }
        public int builtin { get; set; }
        public string? permissions { get; set; }
        public string issues_visibility { get; set; }
        public string users_visibility { get; set; }
        public string time_entries_visibility { get; set; }
        public byte all_roles_managed { get; set; }
        public string? settings { get; set; }
    }
}
}
