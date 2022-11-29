using LittleThings.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LittleThings.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //seeding data to DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SocialMedia>().HasData(
                new SocialMedia
                {
                    Id = 1,
                    Icon = "fab fa-facebook-f",
                    Link = "https://www.facebook.com/"
                }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    RoleName = "Customer",
                    RoleDescription = "Custom role for Customer"
                },
                new Role
                {
                    Id = 3,
                    RoleName = "Admin",
                    RoleDescription = "Custom role for Admin"
                }
            );

            modelBuilder.Entity<SubCategory>().HasData(
               new SubCategory
               {
                   Id = Guid.NewGuid(),
                   Name = "Mens",
               }
            );
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
