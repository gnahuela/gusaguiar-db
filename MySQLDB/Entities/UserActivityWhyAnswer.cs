// Models/UserActivityWhyAnswer.cs

using MySQLDB.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities // Reemplaza "TuProyecto" con tu namespace real
{
    // Nombre de la tabla en la base de datos
    [Table("UserActivityWhyAnswer")]
    public class UserActivityWhyAnswer
    {
        [Key] // Marca la propiedad como clave primaria
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ActivityId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AreaId { get; set; }

        [Required]
        public int LevelIndex { get; set; } // Representa el nivel de 0 a 6

        [Required]
        public string Answer { get; set; } // EF Core lo mapeará a nvarchar(max) o TEXT

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // --- Propiedades de Navegación (Opcional pero recomendado) ---
        // Esto crea la relación de clave foránea con tu tabla de usuarios
        [ForeignKey("UserId")]
        public virtual User User { get; set; } // Asumiendo que tienes una clase User
    }
}