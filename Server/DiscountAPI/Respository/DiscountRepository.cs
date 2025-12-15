using DiscountAPI.Respository.Interface;
using Models;
using Microsoft.EntityFrameworkCore;
using DiscountService.Data;

namespace DiscountAPI.Respository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DiscountDbContext _context;

        public DiscountRepository(DiscountDbContext context)
        {
            _context = context;
        }

        public IQueryable<Discount> GetAll()
        {
            return _context.Discounts
                .Include(d => d.DiscountStadiums)
                .AsQueryable();
        }

        public IQueryable<Discount> GetByStadiumId(int stadiumId)
        {
            return _context.Discounts
                .Include(d => d.DiscountStadiums)
                .Where(d => d.DiscountStadiums.Any(ds => ds.StadiumId == stadiumId));
        }

        public async Task<Discount> CreateAsync(Discount discount)
        {
            discount.CreatedAt = DateTime.UtcNow;
            _context.Discounts.Add(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task UpdateAsync(Discount discount, List<int> stadiumIds)
        {
            var existing = await _context.Discounts
                .Include(d => d.DiscountStadiums)
                .FirstOrDefaultAsync(d => d.Id == discount.Id);

            if (existing == null)
                throw new KeyNotFoundException($"Discount {discount.Id} not found");

            Console.WriteLine("Before update - DiscountStadiums: " + string.Join(", ", existing.DiscountStadiums.Select(ds => ds.StadiumId)));

            // Update các trường cơ bản
            _context.Entry(existing).CurrentValues.SetValues(discount);

            // Xóa các stadium cũ
            existing.DiscountStadiums.Clear();

            // Thêm lại các stadium mới
            if (stadiumIds != null && stadiumIds.Any())
            {
                foreach (var sid in stadiumIds)
                {
                    existing.DiscountStadiums.Add(new DiscountStadium
                    {
                        StadiumId = sid,
                        DiscountId = existing.Id
                    });
                }
            }

            Console.WriteLine("After update - DiscountStadiums: " + string.Join(", ", existing.DiscountStadiums.Select(ds => ds.StadiumId)));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var discount = await _context.Discounts
                .Include(d => d.DiscountStadiums)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (discount != null)
            {
                _context.Discounts.Remove(discount);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Discount?> GetByCodeAsync(string code)
        {
            return await _context.Discounts
                .Include(d => d.DiscountStadiums)
                .FirstOrDefaultAsync(d => d.Code == code);
        }

        public async Task<Discount?> GetByIdAsync(int id)
        {
            return await _context.Discounts
                .Include(d => d.DiscountStadiums)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Discount>> GetExpiredActiveDiscountsAsync()
        {
            var now = DateTime.UtcNow; // Hoặc DateTime.Now tùy hệ thống bạn dùng
            return await _context.Discounts
                .Where(d => d.IsActive == true && d.EndDate <= now)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}