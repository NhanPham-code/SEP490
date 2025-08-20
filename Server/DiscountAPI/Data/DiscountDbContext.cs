using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace DiscountService.Data
{
    public class DiscountDbContext : DbContext
    {
        public DbSet<Discount> Discounts { get; set; }

        public DiscountDbContext(DbContextOptions<DiscountDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Định nghĩa một Value Converter để chuyển đổi List<int> <--> string
            var converter = new ValueConverter<List<int>, string>(
                // Biểu thức để chuyển từ List<int> sang chuỗi (lưu vào DB)
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                // Biểu thức để chuyển từ chuỗi sang List<int> (đọc từ DB)
                v => JsonSerializer.Deserialize<List<int>>(v, (JsonSerializerOptions)null)
            );

            // Áp dụng Value Converter này cho thuộc tính StadiumIds của entity Discount
            modelBuilder.Entity<Discount>()
                .Property(e => e.StadiumIds)
                .HasConversion(converter);
        }
    }
}