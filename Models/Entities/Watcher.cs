using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSupport.Models.Entities
{
    [Table(name:"watchers")]
    public class Watcher
    {
        [Key]
        public int id { get; set; }
        public string watchable_type { get; set; }
        public int watchable_id { get; set; }
        public int user_id { get; set; }
    }
}
