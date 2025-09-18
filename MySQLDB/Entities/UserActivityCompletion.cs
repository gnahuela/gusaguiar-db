//using Microsoft.EntityFrameworkCore;
//using MySQLDB.Entities;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//// [Table] asegura que el nombre de la tabla sea exacto.
//[Table("UserActivityCompletion")]
//// [Index] crea la clave única compuesta sobre UserId y ActivityId.
//[Index(nameof(UserId), nameof(ActivityId), IsUnique = true, Name = "unique_completion")]
//public class UserActivityCompletion
//{
//    // [Key] marca la clave primaria. EF Core lo hará AUTO_INCREMENT por convención.
//    [Key]
//    public int Id { get; set; }

//    [Required]
//    public int UserId { get; set; }

//    [Required]
//    [StringLength(50)] // Genera VARCHAR(50)
//    public string ActivityId { get; set; }

//    // El valor por defecto se configurará con Fluent API en el DbContext
//    // para mayor precisión.
//    public DateTime CompletedAt { get; set; }

//    // --- Relación de Navegación (Opcional pero recomendado) ---
//    // [ForeignKey] define explícitamente la clave foránea para la relación.
//    [ForeignKey(nameof(UserId))]
//    public virtual User User { get; set; }
//}