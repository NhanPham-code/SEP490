using Models;

namespace DiscountAPI.Respository.Interface
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<Discount>> GetAllAsync();
        Task<Discount> GetByIdAsync(int id);
        Task<Discount> GetByCodeAsync(string code);
        Task<Discount> CreateAsync(Discount discount);
        Task UpdateAsync(Discount discount);
        Task DeleteAsync(int id);
    }
}
