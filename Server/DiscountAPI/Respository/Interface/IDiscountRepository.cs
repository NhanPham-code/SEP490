using Models;

namespace DiscountAPI.Respository.Interface
{
    public interface IDiscountRepository
    {
        IQueryable<Discount> GetAll();
        IQueryable<Discount> GetByStadiumId(int stadiumId);

        Task<Discount> CreateAsync(Discount discount);
        Task UpdateAsync(Discount discount, List<int> stadiumIds);
        Task DeleteAsync(int id);
        Task<Discount?> GetByCodeAsync(string code);
        Task<Discount?> GetByIdAsync(int id);
        Task<IEnumerable<Discount>> GetExpiredActiveDiscountsAsync();
        Task SaveChangesAsync();
    }
}
