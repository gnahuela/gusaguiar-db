//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace MySQLDB.Entities
//{
//    [Table("UserToUser")]
//    public class UserToUser : BaseEntity
//    {
//        [Required]
//        public int UserFromId { get; set; }

//        [Required]
//        public int UserToId { get; set; }

//        [Required]
//        public int RoleId { get; set; }

//        public User UserFrom { get; set; }

//        public User UserTo { get; set; }

//        public Role Role { get; set; }
//    }
//}