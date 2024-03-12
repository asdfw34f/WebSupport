using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name: "enabled_modules")]
    public class EnabledModule
    {
        [Key]
        public int id { get; set; }
        public int project_id { get; set; }
        public string name { get; set; }
    }
}
}
