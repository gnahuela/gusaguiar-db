using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities
{
    [Table("UserProduct")]
    public class UserProduct : CrudEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }
    }
}