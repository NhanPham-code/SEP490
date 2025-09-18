using Microsoft.EntityFrameworkCore;
using Models;

namespace DiscountService.Data
{
    public class DiscountDbContext : DbContext
    {
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountStadium> DiscountStadiums { get; set; }

        public DiscountDbContext(DbContextOptions<DiscountDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình quan hệ 1-nhiều giữa Discount và DiscountStadium
            modelBuilder.Entity<DiscountStadium>()
                .HasOne(ds => ds.Discount)
                .WithMany(d => d.DiscountStadiums)
                .HasForeignKey(ds => ds.DiscountId)
                .OnDelete(DeleteBehavior.Cascade);

            // Index để query nhanh hơn (tìm discount theo StadiumId)
            modelBuilder.Entity<DiscountStadium>()
                .HasIndex(ds => ds.StadiumId);
        }
    }
}
