using LittleThings.Shared;
using Microsoft.EntityFrameworkCore;

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
                    Link = "https://www.facebook.com/",
                    InNewTab = true
                }
            );
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
    }
}
