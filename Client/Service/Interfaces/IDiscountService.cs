using DTOs.DiscountDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IDiscountService
    {
        // Changed to return nullable Task to reflect the implementation
        Task<List<ReadDiscountDTO>?> GetAllDiscountsAsync();

        Task<ReadDiscountDTO?> GetDiscountByIdAsync(int id);
        Task<ReadDiscountDTO?> GetDiscountByCodeAsync(string code);

        // Changed to return nullable Task to reflect the implementation
        Task<List<ReadDiscountDTO>?> GetDiscountsByStadiumIdAsync(int stadiumId);

        // Changed to return nullable Task to reflect the implementation
        Task<ReadDiscountDTO?> CreateDiscountAsync(CreateDiscountDTO dto);

        // Corrected DTO type for Update
        Task<bool> UpdateDiscountAsync(UpdateDiscountDTO dto);
    }
}