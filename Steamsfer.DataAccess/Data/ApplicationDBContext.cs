using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Steamsfer.Models;

namespace Steamsfer.DataAccess.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        //Setting connection string 
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData
                (
                new Category { Id = 1, Name = "Category1", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Category2", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Category3", DisplayOrder = 3 }
                );

            modelBuilder.Entity<UserRole>().HasData
                (
                new UserRole { Id = 1, Role = "Admin", Description = "Administrator role with full access to all database objects" },
                new UserRole { Id = 2, Role = "User", Description = "Logged in user" },
                new UserRole { Id = 3, Role = "Guest", Description = "Guest users without logging in" }
                );
            modelBuilder.Entity<User>().HasData
                (
                new User
                {
                    Id = 1,
                    UserName = "erenvbn",
                    Email = "erenvbn@gmail.com",
                    Password = "12345678",
                    AvatarURL="",
                    UserRoleId = 1,
                },
                new User
                {
                    Id = 2,
                    UserName = "benguvbn",
                    Email = "erenvbn2@gmail.com",
                    Password = "12345678",
                    AvatarURL = "",
                    UserRoleId = 2,
                },
                new User
                {
                    Id = 3,
                    UserName = "emrevbn",
                    Email = "erenvbn3@gmail.com",
                    Password = "12345678",
                    AvatarURL = "",
                    UserRoleId = 3,
                }
                ); ; 
        }

    }
}
