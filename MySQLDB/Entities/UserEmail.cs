using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities
{
    [Table("UserEmail")]
    public class UserEmail : CrudEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(333)]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        [Required]
        public int Step { get; set; }

        [MaxLength(50)]
        public string? After { get; set; }

        [MaxLength(50)]
        public string? At { get; set; }

        [MaxLength(50)]
        public string? File { get; set; }

        [MaxLength(50)]
        public string? Folder { get; set; }

        [MaxLength(1500)]
        public string? Description { get; set; }

        [MaxLength(1500)]
        public string? Actions { get; set; }

        [MaxLength(1500)]
        public string? Gifts { get; set; }

        public User User { get; set; }
    }
}