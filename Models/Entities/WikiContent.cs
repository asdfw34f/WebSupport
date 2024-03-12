using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSupport.Models.Entities
{
    [Table(name:"wiki_contents")]
    public class WikiContent
    {
        [Key]
        public int id { get; set; }
        public int page_id { get; set; }
        public int author_id { get; set; }
        public string text {get;set;}
        public string comments { get; set; }
        public DateTime updated_on { get; set; }
        public int version { get; set; }
    }
}
