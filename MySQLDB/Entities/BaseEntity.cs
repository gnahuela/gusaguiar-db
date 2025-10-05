using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MySQLDB.Entities
{
    [Index(nameof(Code), IsUnique = true)]
    public abstract class CodeEntity : BaseEntity
    {
        [Required]
        public string Code { get; set; }
    }

    public abstract class CrudEntity : BaseEntity
    {
        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }

    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
