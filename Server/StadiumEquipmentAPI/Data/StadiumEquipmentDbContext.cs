using Microsoft.EntityFrameworkCore;
using StadiumEquipmentAPI.Models;

namespace StadiumEquipmentAPI.Data
{
    public class StadiumEquipmentDbContext : DbContext
    {
        public StadiumEquipmentDbContext(DbContextOptions<StadiumEquipmentDbContext> options) : base(options)
        {
        }

        public DbSet<StadiumEquipments> StadiumEquipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StadiumEquipments>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Status).HasMaxLength(50).HasDefaultValue("Active");
                entity.Property(e => e.ImagePath).HasMaxLength(500);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");
            });
        }
    }
}