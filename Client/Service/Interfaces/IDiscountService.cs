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
        Task<ReadDiscountDTO?> CreateDiscountAsync(string accessToken, CreateDiscountDTO dto);

        // Corrected DTO type for Update
        Task<bool> UpdateDiscountAsync(string accessToken, UpdateDiscountDTO dto);

        Task<List<ReadDiscountDTO>?> GetDiscountsByUserAsync(
            string accessToken,
            string userId,
            int page = 1,
            int pageSize = 5,
            string? searchByCode = null,
            int? stadiumId = null,
            bool? isActive = null);
    }
}