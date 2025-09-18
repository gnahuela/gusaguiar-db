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

        public string Name { get; set; }

        public string NickName { get; set; }

        public string FirstNames { get; set; }

        public string LastNames { get; set; }

        public bool IsJustLead { get; set; }

        public bool IsVerified { get; set; }

        [MaxLength(255)]
        public string? ConfirmationToken { get; set; }

        public DateTime? TokenExpiresAt { get; set; }
    }
}