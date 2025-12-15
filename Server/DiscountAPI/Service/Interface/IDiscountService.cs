using DiscountAPI.DTO;

namespace DiscountAPI.Service.Interface
{
    public interface IDiscountService
    {
        IQueryable<ReadDiscountDTO> GetAll();
        IQueryable<ReadDiscountDTO> GetByStadiumId(int stadiumId);
        Task<ReadDiscountDTO?> GetByIdAsync(int id);
        Task<ReadDiscountDTO?> GetByCodeAsync(string code);
        Task<ReadDiscountDTO> CreateAsync(CreateDiscountDTO dto);
        Task UpdateAsync(UpdateDiscountDTO dto);
        Task DeleteAsync(int id);
        Task ScanAndDeactivateExpiredDiscountsAsync();
    }

}
