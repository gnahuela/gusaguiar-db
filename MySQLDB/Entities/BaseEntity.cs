using System.ComponentModel.DataAnnotations;

namespace MySQLDB.Entities
{
    public abstract class CrudEntity : BaseEntity
    {
        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public DateTime? DateDeleted { get; set; }
    }

    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
