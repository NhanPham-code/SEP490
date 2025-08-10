using Microsoft.EntityFrameworkCore;
using Models;

namespace DiscountService.Data
{
    public class DiscountDbContext : DbContext
    {
        public DiscountDbContext(DbContextOptions<DiscountDbContext> options)
            : base(options) { }

        public DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add FluentAPI if needed
        }
    }
}
