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

        public async Task<IEnumerable<Discount>> GetAllAsync()
        {
            return await _context.Set<Discount>().ToListAsync();
        }

        public async Task<Discount> GetByIdAsync(int id)
        {
            return await _context.Set<Discount>().FindAsync(id);
        }

        public async Task<Discount> GetByCodeAsync(string code)
        {
            return await _context.Set<Discount>().FirstOrDefaultAsync(d => d.Code == code);
        }

        public async Task<Discount> CreateAsync(Discount discount)
        {
            discount.CreatedAt = DateTime.UtcNow;
            _context.Set<Discount>().Add(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task UpdateAsync(Discount discount)
        {
            _context.Set<Discount>().Update(discount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var discount = await GetByIdAsync(id);
            if (discount != null)
            {
                _context.Set<Discount>().Remove(discount);
                await _context.SaveChangesAsync();
            }
        }
    }

}
