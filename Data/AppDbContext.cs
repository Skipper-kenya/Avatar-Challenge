using Avatar_Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Avatar_Challenge.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Samsung", Price = 10000, SerialNumberId = 10 }
                );

            modelBuilder.Entity<SerialNumber>().HasData(
              new SerialNumber { Id = 10, Name = "Galaxy A12", ItemId = 1 }
              );


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<AvatarModel> Avatars { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<SerialNumber> SerialNumber { get; set; }
    }
}
