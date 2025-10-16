using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities
{
    [Table("User")]
    public class User : CrudEntity
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string? Nick { get; set; }

        [MaxLength(200)]
        public string? Name { get; set; }

        [MaxLength(200)]
        public string? FirstNames { get; set; }

        [MaxLength(200)]
        public string? LastNames { get; set; }

        public string? Subscriptions { get; set; }

        public bool IsJustLead { get; set; }

        public bool IsVerified { get; set; }

        [MaxLength(255)]
        public string? ConfirmationToken { get; set; }

        public DateTime? TokenExpiresAt { get; set; }

        [MaxLength(333)]
        public string? FirstInterests { get; set; }
    }
}