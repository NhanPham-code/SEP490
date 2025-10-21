using FeeAPI.Data;
using FeeAPI.Model;
using FeeAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FeeAPI.Repository
{
    public class FeeRepository : IFeeRepository
    {
        private readonly FeeDbContext _context;

        public FeeRepository(FeeDbContext context)
        {
            _context = context;
        }

        public async Task<Fee> CreateFeeAsync(Fee fee)
        {
            var result = await _context.AddAsync(fee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteFeeAsync(int id)
        {
            var fee = await _context.Fees.FindAsync(id);
            if (fee == null)
            {
                return false;
            }
            _context.Fees.Remove(fee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Fee>> GetAllFeesAsync()
        {
            var fees = await _context.Fees.ToListAsync();
            return fees;
        }

        public async Task<Fee?> GetFeeByIdAsync(int id)
        {
            var fee = await _context.Fees.FindAsync(id);
            return fee;
        }

        public async Task<List<Fee>> GetFeesByMonthYearAsync(int month, int year)
        {
            var fees = await _context.Fees
                .Where(f => f.Month == month && f.Year == year)
                .ToListAsync();
            return fees;
        }

        public async Task<List<Fee>> GetFeesByOwnerIdAsync(int ownerId)
        {
            var fees = await _context.Fees
                .Where(f => f.OwnerId == ownerId)
                .ToListAsync();
            return fees;
        }

        public async Task<List<Fee>> GetFeesByStadiumIdAsync(int stadiumId)
        {
            var fees = await _context.Fees
                .Where(f => f.StadiumId == stadiumId)
                .ToListAsync();
            return fees;
        }

        public async Task<Fee?> UpdateFeeAsync(int id, Fee fee)
        {
            var existingFee = await _context.Fees.FindAsync(id);
            if (existingFee == null)
            {
                return null;
            }
            _context.Entry(existingFee).CurrentValues.SetValues(fee);
            await _context.SaveChangesAsync();
            return existingFee;
        }

        public IQueryable<Fee> GetFeesAsQueryable()
        {
            return _context.Fees.AsQueryable();
        }
    }
}
