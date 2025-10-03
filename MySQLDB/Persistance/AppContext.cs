using Microsoft.EntityFrameworkCore;
using MySQLDB.Entities;

namespace MySQLDB.Persistance
{
    public class CDotsContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<TrackLog> TrackLogs { get; set; }

        public CDotsContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=gusaguiar;Uid=admin;Pwd=CDots8013.;");

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

            new EntitiesSeeder(this, modelBuilder).SeedData();
        }
    }
}