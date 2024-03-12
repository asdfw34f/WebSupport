using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSupport.Models.Entities
{
    [Table(name:"changes")]
    public class Changes
    {
        [Key]
        public int id { get; set; }
        public int changeset_id { get; set; }
        public string? action {  get; set; }
        public string? path { get; set; }
        public string? from_path { get; set; }
        public string? from_revision { get; set; }
        public string? revision { get; set; }
        public string? branch { get; set; }
    }
}
