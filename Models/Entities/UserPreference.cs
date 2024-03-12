using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSupport.Models.Entities
{
    [Table(name:"user_preferences")]
    public class UserPreference
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public string others { get; set; }
        public byte hide_mail { get; set; }
        public string time_zone { get; set; }
    }
}
