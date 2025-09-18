using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities
{

    [Table("Lead")]
    public class Lead : CrudEntity
    {
        [Required]
        public string NickName { get; set; }

        public string FirstNames { get; set; }

        public string LastNames { get; set; }

        public DateTime? DateUnsubscribed { get; set; }

        [Required]
        public string Email { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }
    }
}