using BlazorDemo.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Price).HasPrecision(10, 2);
                entity.Property(e => e.Category).IsRequired().HasMaxLength(50);
                entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.HasIndex(e => e.Category);
                entity.HasIndex(e => e.Name);
            });
        }
    }
}
