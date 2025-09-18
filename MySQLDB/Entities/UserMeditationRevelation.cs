//// Models/UserMeditationRevelation.cs

//using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace MySQLDB.Entities
//{
//    [Table("UserMeditationRevelation")]
//    public class UserMeditationRevelation
//    {
//        [Key]
//        public int Id { get; set; }

//        [Required]
//        public int UserId { get; set; }

//        [Required]
//        public string Revelation { get; set; }

//        [Required]
//        public int TotalTimeMeditated { get; set; } // En segundos

//        // Columnas de seguimiento estándar
//        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
//        public DateTime? DateUpdated { get; set; }
//        public DateTime? DateDeleted { get; set; }

//        // Propiedad de Navegación
//        [ForeignKey("UserId")]
//        public virtual User User { get; set; }
//    }
//}