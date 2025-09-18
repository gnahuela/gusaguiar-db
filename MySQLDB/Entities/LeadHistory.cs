using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities
{
    [Table("LeadHistory")]
    public class LeadHistory : CrudEntity
    {
        [Required]
        public int LeadId { get; set; }

        [Required]
        public string Page { get; set; }

        [Required]
        public string Section { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string Status { get; set; }

        public Lead Lead { get; set; }
    }
}