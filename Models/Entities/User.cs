using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSupport.Models.Entities
{
    [Table(name:"users")]
    public class User
    {
        [Key]
        public int id { get; set; }
        public string login { get; set; }
        public string hashed_password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public byte admin { get; set; }
        public int status { get; set; }
        public DateTime last_login_on { get; set; }
        public string language { get; set; }
        public int auth_source_id { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }
        public string type { get; set; }
        public string identity_url { get; set; }
        public string mail_notification { get; set; }
        public string salt { get; set; }
        public byte must_change_passwd { get; set; }
        public DateTime passwd_changed_on { get; set; }
    }
}
