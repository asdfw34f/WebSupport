using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSupport.Models.Entities
{
    [Table(name:"wiki_redirects")]
    public class WikiRedirect
    {
        [Key]
        public int id { get; set; }
        public int wiki_id { get; set; }
        public string title { get; set; }
        public string redirects_to { get; set; }
        public DateTime created_on { get; set; }
        public int redirects_to_wiki_id { get; set; }
    }
}
