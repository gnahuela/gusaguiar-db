using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities
{
    [Table("AppNotification")]
    public class AppNotification : CrudEntity
    { 
        [Required]
        public string Message { get; set; }
    }
}