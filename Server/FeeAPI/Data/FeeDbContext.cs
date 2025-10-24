using FeeAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FeeAPI.Data
{
    public class FeeDbContext : DbContext
    {
        public FeeDbContext(DbContextOptions<FeeDbContext> options) : base(options)
        {
        }

        public DbSet<Fee> Fees { get; set; }
    }
}
