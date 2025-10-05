using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities
{
    [Table("UserProductItem")]
    public class UserProductItem : CrudEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductItemId { get; set; }

        public User User { get; set; }

        public ProductItem ProductItem { get; set; }
    }
}