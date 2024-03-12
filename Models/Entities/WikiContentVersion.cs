using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSupport.Models.Entities
{
    [Table(name:"wiki_content_versions")]
    public class WikiContentVersion
    {
        [Key]
        public int id { get; set; }
        public int wiki_content_id { get; set; }
        public int page_id { get; set; }
        public int author_id { get; set; }
        public string data { get; set; }
        public string compression { get; set; }
        public string comments { get; set; }
        public DateTime updated_on { get; set; }
        public int version { get; set; }
    }
}
