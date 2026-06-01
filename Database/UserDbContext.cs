using HAK_BlazorPicoTemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace HAK_BlazorPicoTemplate.Database
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.Property(e => e.Id).HasColumnName("userid");
                entity.Property(e => e.Username).HasColumnName("username");
                entity.Property(e => e.Password).HasMaxLength(255).HasColumnName("password");

            }

            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
