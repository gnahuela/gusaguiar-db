using Microsoft.EntityFrameworkCore;
using MySQLDB.Entities;

namespace MySQLDB.Persistance
{
    public class CDotsContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<TrackLog> TrackLogs { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductItem> ProductItems { get; set; }

        public DbSet<UserProduct> UserProducts { get; set; }

        public DbSet<UserProductItem> UserProductItems { get; set; }

        public DbSet<UserEmail> UserEmails { get; set; }

        public DbSet<TrackEmail> TrackEmails { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        #region Es

        public DbSet<EsProduct> EsProducts { get; set; }

        public DbSet<EsProductItem> EsProductItems { get; set; }

        #endregion

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

            modelBuilder.Entity<UserProductItem>()
                .HasIndex(upi => new { upi.UserId, upi.ProductItemId })
                .IsUnique();

            modelBuilder.Entity<UserProduct>()
                .HasIndex(upi => new { upi.UserId, upi.ProductId })
                .IsUnique();

            modelBuilder.Entity<UserEmail>()
                .HasIndex(upi => new { upi.UserId, upi.Step, upi.Code })
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