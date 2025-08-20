using DiscountAPI.Respository.Interface;
using Models;
using Microsoft.EntityFrameworkCore;
using DiscountService.Data;
using Microsoft.IdentityModel.Tokens;

namespace DiscountAPI.Respository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DiscountDbContext _context;

        public DiscountRepository(DiscountDbContext context)
        {
            _context = context;
        }

        // OData - Get all, để dùng OData filter
        public IQueryable<Discount> GetAll()
        {
            return _context.Discounts.AsQueryable();
        }

        // Lọc Discount áp dụng cho 1 sân cụ thể
        // Sử dụng cách tiếp cận Value Converter để lọc trên bộ nhớ
        public IQueryable<Discount> GetByStadiumId(int stadiumId)
        {
            // Cảnh báo: Cách này không hiệu quả với tập dữ liệu lớn.
            // Nếu có thể, nên xem xét tạo bảng trung gian.
            // Chuyển sang AsEnumerable() để lọc trên bộ nhớ.
            return _context.Discounts.AsEnumerable()
                                     .Where(d => d.StadiumIds != null && d.StadiumIds.Contains(stadiumId))
                                     .AsQueryable();
        }

        // Tạo mới
        public async Task<Discount> CreateAsync(Discount discount)
        {
            discount.CreatedAt = DateTime.UtcNow;
            _context.Discounts.Add(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        // Cập nhật
        public async Task UpdateAsync(Discount discount)
        {
            // Attach và cập nhật trạng thái của entity
            _context.Entry(discount).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Xoá
        public async Task DeleteAsync(int id)
        {
            var discount = await _context.Discounts.FindAsync(id);
            if (discount != null)
            {
                _context.Discounts.Remove(discount);
                await _context.SaveChangesAsync();
            }
        }

        // Kiểm tra mã code
        public async Task<Discount?> GetByCodeAsync(string code)
        {
            return await _context.Discounts.FirstOrDefaultAsync(d => d.Code == code);
        }

        // Lấy theo ID
        public async Task<Discount?> GetByIdAsync(int id)
        {
            return await _context.Discounts.FindAsync(id);
        }
    }
}