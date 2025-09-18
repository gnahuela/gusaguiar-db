//// Namespaces
//using Microsoft.EntityFrameworkCore;
//using MySQLDB.Entities;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace MySQLDB.Entities
//{
//    /// <summary>
//    /// Almacena un objetivo de manifestación y su progreso en la actividad "Umbral de la Creencia".
//    /// Cada registro es un objetivo único para un usuario.
//    /// </summary>
//    [Table("UserActivityBeliefThreshold")]
//    public class UserActivityBeliefThreshold
//    {
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int Id { get; set; } // Ahora es la clave principal para cada objetivo

//        [Required]
//        public int UserId { get; set; }

//        [Required]
//        [StringLength(50)]
//        public string ActivityId { get; set; } // Se mantiene para agrupar

//        [Required]
//        [Column(TypeName = "text")]
//        public string ManifestGoal { get; set; }

//        [Column(TypeName = "json")]
//        public string? Hesitations { get; set; }

//        [Required]
//        public int CurrentTimeIndex { get; set; }

//        // --- NUEVOS CAMPOS ---
//        [StringLength(255)]
//        public string? PerfectTimeFrameLabel { get; set; } // Ej: "1 año"

//        [Column(TypeName = "decimal(10, 4)")]
//        public decimal? PerfectTimeFrameYears { get; set; } // Ej: 1.0000 o 0.5000

//        // --- FIN DE NUEVOS CAMPOS ---

//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public DateTime CreatedAt { get; set; }

//        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
//        public DateTime UpdatedAt { get; set; }

//        [ForeignKey(nameof(UserId))]
//        public virtual User User { get; set; }
//    }
//}