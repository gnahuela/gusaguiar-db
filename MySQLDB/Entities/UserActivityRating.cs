//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MySQLDB.Entities
//{
//    [Table("UserActivityRating")]
//    public class UserActivityRating
//    {        /// <summary>
//             /// Identificador único de la calificación. Clave primaria autoincremental.
//             /// </summary>
//        [Key]
//        public int Id { get; set; }

//        /// <summary>
//        /// Clave foránea que referencia al usuario que realizó la calificación.
//        /// </summary>
//        [Required]
//        public int UserId { get; set; }

//        /// <summary>
//        /// Identificador de la actividad a la que pertenece la calificación (p. ej., "twelve_areas_balance").
//        /// </summary>
//        [Required]
//        [MaxLength(50)]
//        public string ActivityId { get; set; }

//        /// <summary>
//        /// Identificador del área específica calificada dentro de la actividad (p. ej., "finances", "health").
//        /// </summary>
//        [Required]
//        [MaxLength(50)]
//        public string AreaId { get; set; }

//        /// <summary>
//        /// Puntuación asignada por el usuario (0-10).
//        /// </summary>
//        [Required]
//        public byte Score { get; set; } // byte es perfecto para un TINYINT (0-255)

//        /// <summary>
//        /// Número de intento. Permite al usuario repetir la actividad y comparar resultados.
//        /// </summary>
//        [Required]
//        public int AttemptNumber { get; set; }

//        /// <summary>
//        /// Fecha y hora en que se registró la calificación.
//        /// </summary>
//        public DateTime RatedAt { get; set; }

//        // --- Propiedad de Navegación ---

//        /// <summary>
//        /// Propiedad de navegación hacia la entidad User.
//        /// </summary>
//        [ForeignKey("UserId")]
//        public virtual User User { get; set; }
//    }
//}
