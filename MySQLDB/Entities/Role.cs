using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities
{
    [Table("Role")]
    public class Role : CrudEntity
    {
        [Required]
        public string RoleName { get; set; }
    }
}