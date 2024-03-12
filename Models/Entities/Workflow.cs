using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSupport.Models.Entities
{
    [Table(name:"workflows")]
    public class Workflow
    {
        [Key]
        public int id { get; set; }
        public int tracker_id { get; set; }
        public int old_status_id { get; set; }
        public int new_status_id { get; set; }
        public int role_id { get; set; }
        public byte assignee { get; set; }
        public byte author { get; set; }
        public string type { get; set; }
        public string field_name { get; set; }
        public string rule { get; set; }
    }
}
