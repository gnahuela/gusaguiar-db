//using Microsoft.EntityFrameworkCore;
//using MySQLDB.Entities;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//// La anotación [Table] asegura que EF Core use el nombre exacto "UserActivityDefinition" 
//// en la base de datos, en lugar de pluralizarlo a "UserActivityDefinitions".
//[Table("UserActivityDefinition")]
//// La anotación [Index] crea la clave única compuesta. `nameof()` previene errores de tipeo.
//[Index(nameof(UserId), nameof(ActivityId), nameof(AreaId), IsUnique = true, Name = "unique_definition")]
//public class UserActivityDefinition
//{
//    // [Key] identifica esta propiedad como la clave primaria.
//    // EF Core entiende que un `int` llamado `Id` es una columna de identidad (AUTO_INCREMENT).
//    [Key]
//    public int Id { get; set; }

//    // Esta es la propiedad de clave foránea.
//    [Required]
//    public int UserId { get; set; }

//    [Required]
//    [StringLength(50)] // Corresponde a VARCHAR(50)
//    public string ActivityId { get; set; }

//    [Required]
//    [StringLength(50)] // Corresponde a VARCHAR(50)
//    public string AreaId { get; set; }

//    [Required]
//    [Column(TypeName = "TEXT")] // Especifica explícitamente el tipo de columna para MySQL.
//    public string Definition { get; set; }

//    // NOTA: Los valores por defecto de la base de datos (DEFAULT CURRENT_TIMESTAMP)
//    // se configuran de forma más robusta usando la "Fluent API" en tu DbContext.
//    // Ver la explicación más abajo.
//    public DateTime CreatedAt { get; set; }

//    public DateTime UpdatedAt { get; set; }

//    // --- Relación de Navegación ---
//    // [ForeignKey] le dice a EF Core que `UserId` es la clave foránea para esta relación.
//    // La propiedad `virtual` permite la carga diferida (lazy loading).
//    [ForeignKey(nameof(UserId))]
//    public virtual User User { get; set; }
//}