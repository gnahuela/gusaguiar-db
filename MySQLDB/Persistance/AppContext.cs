using Microsoft.EntityFrameworkCore;
using MySQLDB.Entities;

namespace MySQLDB.Persistance
{
    public class CDotsContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public CDotsContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=admin;Uid=cdots;Pwd=CDots8013.;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(l => l.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(l => l.Username)
                .IsUnique();

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var entity = modelBuilder.Entity(entityType.ClrType);

                var dateProperties = entityType.ClrType
                    .GetProperties()
                    .Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?));

                foreach (var prop in dateProperties)
                {
                    entity
                        .Property(prop.Name)
                        .HasColumnType("DATETIME");

                    if (prop.Name == "CreatedAt")
                    {
                        entity
                            .Property(prop.Name)
                            .HasDefaultValueSql("CURRENT_TIMESTAMP");
                    }
                }
            }

            modelBuilder.Entity<UserActivityRating>(entity =>
            {
                // Clave única compuesta para asegurar que un usuario no califique
                // la misma área dos veces en el mismo intento.
                // Corresponde a: UNIQUE KEY `unique_rating_attempt` (`UserId`, `ActivityId`, `AreaId`, `AttemptNumber`)
                entity.HasIndex(e => new { e.UserId, e.ActivityId, e.AreaId, e.AttemptNumber })
                      .IsUnique()
                      .HasDatabaseName("IX_UserActivityRatings_UniqueAttempt"); // Nombre explícito para el índice

                // Valor por defecto para AttemptNumber.
                // Corresponde a: DEFAULT 1
                entity.Property(e => e.AttemptNumber)
                      .HasDefaultValue(1)
                      .HasComment("To group ratings for each take");

                // Valor por defecto para RatedAt usando la función de la base de datos.
                // Corresponde a: DEFAULT CURRENT_TIMESTAMP
                entity.Property(e => e.RatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // Configuración de la relación con User y el comportamiento de borrado en cascada.
                // Corresponde a: FOREIGN KEY (`UserId`) REFERENCES `User`(`Id`) ON DELETE CASCADE
                entity.HasOne(d => d.User)
                      .WithMany() // Asumiendo que User no tiene una colección de Ratings
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Añadir comentarios a las columnas para mayor claridad en la base de datos.
                entity.Property(e => e.ActivityId).HasComment("e.g., twelve_areas_balance");
                entity.Property(e => e.AreaId).HasComment("e.g., finances, health");
            });

            // Configuración para la entidad UserActivityDefinition
            modelBuilder.Entity<UserActivityDefinition>(entity =>
            {
                // Configura el valor por defecto para CreatedAt en el momento de la creación.
                entity.Property(e => e.CreatedAt)
                      .ValueGeneratedOnAdd() // Se genera al añadir
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // Configura el valor para UpdatedAt para que se actualice tanto en la creación como en la modificación.
                // Esto es específico para el proveedor de MySQL (Pomelo).
                entity.Property(e => e.UpdatedAt)
                      .ValueGeneratedOnAddOrUpdate() // Se genera al añadir o actualizar
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // La relación y la eliminación en cascada (ON DELETE CASCADE)
                // suelen ser detectadas por convención de EF Core, pero si quieres ser explícito:
                entity.HasOne(d => d.User)
                      .WithMany() // Asumiendo que User no tiene una colección de UserActivityDefinition
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.Cascade); // Esto coincide con ON DELETE CASCADE
            });

            modelBuilder.Entity<UserActivityCompletion>(entity =>
            {
                // Configura el valor por defecto de 'CompletedAt' para que se genere
                // en la base de datos al crear un nuevo registro.
                entity.Property(e => e.CompletedAt)
                      .ValueGeneratedOnAdd()
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // Confirma la relación y el comportamiento de borrado en cascada (ON DELETE CASCADE)
                // Esto es a menudo el comportamiento por defecto para claves foráneas requeridas,
                // pero ser explícito es una buena práctica.
                entity.HasOne(d => d.User)
                      .WithMany() // Asumiendo que User no tiene una colección de UserActivityCompletion
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserActivityWhyAnswer>(entity =>
            {
                // Crear un índice único compuesto. Esto asegura que un usuario no pueda
                // tener dos respuestas para el mismo nivel de la misma área y actividad.
                entity.HasIndex(e => new { e.UserId, e.ActivityId, e.AreaId, e.LevelIndex })
                      .IsUnique()
                      .HasDatabaseName("IX_UserActivityWhyAnswer_UniqueResponse"); // Nombre del índice

                // Configurar el comportamiento de CreatedAt al añadir una nueva entidad
                entity.Property(e => e.CreatedAt)
                      .ValueGeneratedOnAdd()
                      .HasDefaultValueSql("CURRENT_TIMESTAMP"); // Para SQL Server. Usa "CURRENT_TIMESTAMP" para MySQL

                // Configurar el comportamiento de UpdatedAt al añadir o modificar
                entity.Property(e => e.UpdatedAt)
                     .ValueGeneratedOnAddOrUpdate()
                     .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<UserActivityBeliefThreshold>(entity =>
            {
                // La clave primaria y el índice único ya están definidos por atributos,
                // pero se pueden configurar aquí también si lo prefieres.
                // entity.HasKey(e => e.Id);
                // entity.HasIndex(e => new { e.UserId, e.ActivityId }).IsUnique();

                // Configuración de propiedades específicas
                entity.Property(e => e.ManifestGoal)
                    .HasColumnType("text")
                    .IsRequired();

                entity.Property(e => e.Hesitations)
                    .HasColumnType("json")
                    .IsRequired(false); // La columna puede ser nula

                // Configuración para que MySQL gestione las marcas de tiempo automáticamente
                entity.Property(e => e.CreatedAt)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt)
                    .ValueGeneratedOnAddOrUpdate() // Esto requiere el proveedor Pomelo.EntityFrameworkCore.MySql
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");

                // Configuración de la relación con la tabla User
                entity.HasOne(e => e.User)
                    .WithMany() // Asumiendo que User no tiene una colección de estas entidades
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade); // Si se borra un usuario, se borra su progreso
            });

            new EntitiesSeeder(this, modelBuilder).SeedData();
        }
    }
}