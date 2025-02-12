using Avatar_Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Avatar_Challenge.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<AvatarModel> Avatars { get; set; }
    }
}
