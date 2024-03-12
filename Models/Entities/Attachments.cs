using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSupport.Models.Entities
{
    [Table(name:"attachments")]
    public class Attachments
    {
        [Key]
        public int id { get; set; }
        public int container_id { get; set; }
        public string container_type { get; set; }
        public string filename { get; set; }
        public string disk_filename { get; set; }
        public Int64 filesize { get; set; }
        public string content_type { get; set; }
        public string digest { get; set; }
        public int downloads { get; set; }
        public int author_id { get; set; }
        public DateTime created_on { get; set; }
        public string description { get; set; }
        public string disk_directory { get; set; }
    }
}
