using Microsoft.EntityFrameworkCore;
using MySQLDB.Entities;

namespace MySQLDB.Persistance
{
    internal class EntitiesSeeder
    {
        private CDotsContext _context;
        private ModelBuilder _modelBuilder;
        private const int GNAHUELAID = 1;
        private const int SUPER = 2;

        public EntitiesSeeder(CDotsContext context, ModelBuilder modelBuilder)
        {
            _context = context;
            _modelBuilder = modelBuilder;
        }

        public void SeedData()
        {
            var gnahuela = new User
            {
                Email = "gustavonahuelaguiar@gmail.com",
                Password = "3a14489f6192f9b2d31466c234ed34b3",
                Username = "Gus",
                Id = GNAHUELAID,
                IsVerified = true,
            };

            var superadmin = new User
            {
                Email = "super@super.com",
                Password = "1b3231655cebb7a1f783eddf27d254ca",
                Username = "Super",
                Id = SUPER,
                IsVerified = true,
            };

            _modelBuilder.Entity<User>().HasData(gnahuela);
            _modelBuilder.Entity<User>().HasData(superadmin);

            var roles = new List<Role>()
            {
                new Role
                {
                    Id = 1,
                    RoleName = "SuperAdmin"
                },
                new Role
                {
                    Id = 2,
                    RoleName = "Admin"
                },
                new Role
                {
                    Id = 3,
                    RoleName = "Regular"
                },
                new Role
                {
                    Id = 4,
                    RoleName = "Coach"
                }
            };

            foreach (var role in roles)
            {
                _modelBuilder.Entity<Role>().HasData(role);
            }

            var coach = new UserToUser
            {
                Id = 1,
                UserFromId = 2,
                UserToId = 1,
                RoleId = 4
            };

            _modelBuilder.Entity<UserToUser>().HasData(coach);

            var userRoles = new List<UserRole>
            {
                new UserRole
                {
                    Id = 1,
                    UserId = 1,
                    RoleId = 3
                },
                new UserRole
                {
                    Id = 2,
                    UserId = 2,
                    RoleId = 1
                },
            };

            foreach (var role in userRoles)
            {
                _modelBuilder.Entity<UserRole>().HasData(role);
            }
        }
    }
}