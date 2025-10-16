using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities
{
    [Table("Subscription")]
    public class Subscription : CrudEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(333)]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        [MaxLength(1500)]
        public string? Expectations { get; set; }

        [MaxLength(1500)]
        public string? OtherReasons { get; set; }

        [MaxLength(1500)]
        public string? Improvements { get; set; }

        [MaxLength(1500)]
        public string? Reasons { get; set; }

        public User User { get; set; }
    }
}