using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities
{
    [Table("User")]
    public class User : CrudEntity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsVerified { get; set; }

        public bool HasPaid { get; set; }

        [MaxLength(255)]
        public string? ConfirmationToken { get; set; }

        public DateTime? TokenExpiresAt { get; set; }
    }
}