using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSupport.Models.Entities
{
    [Table(name:"wikis")]
    public class Wiki
    {
        [Key]
        public int id { get; set; }
        public int project_id { get; set; }
        public string start_page { get; set; }
        public int status { get; set; }
    }
}
