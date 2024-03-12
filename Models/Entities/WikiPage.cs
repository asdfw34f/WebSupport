using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSupport.Models.Entities
{
    [Table(name: "wiki_pages")]
    public class WikiPage
    {
        [Key]
        public int id { get; set; }
        public int wiki_id { get; set; }
        public string title { get; set; }
        public DateTime created_on { get; set; }
        [Column(name: "protected")]
        public byte _protected { get; set; }
        public int parent_id { get; set; }
    }

}
