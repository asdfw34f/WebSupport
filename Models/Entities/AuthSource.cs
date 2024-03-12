using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name: "auth_sources")]
    public class AuthSource
    {
        [Key]
        public int id { get; set; }
        public string? type { get; set; }
        public string? name { get; set; }
        public string? host { get; set; }
        public int port { get; set; }
        public string? account { get; set; }
        public string? account_password { get; set; }
        public string? base_dn { get; set; }
        public string? attr_login { get; set; }
        public string? attr_firstname{ get; set; }
        public string? attr_lastname { get; set; }
        public string? attr_mail { get; set; }
        public byte onthefly_register { get; set; }
        public byte tls { get; set; }
        public string? filter { get; set; }
        public int timeout{ get; set; }
    }
}
