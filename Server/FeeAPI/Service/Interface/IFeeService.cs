using FeeAPI.DTOs;
using FeeAPI.Model;

namespace FeeAPI.Service.Interface
{
    public interface IFeeService
    {
        Task<List<Fee>> GetAllFeesAsync();

        Task<Fee?> GetFeeByIdAsync(int id);

        Task<Fee> CreateFeeAsync(Fee fee);

        Task<Fee?> UpdateFeeAsync(int id, Fee fee);

        Task<bool> DeleteFeeAsync(int id);

        Task<List<Fee>> GetFeesByOwnerIdAsync(int ownerId);

        Task<List<Fee>> GetFeesByStadiumIdAsync(int stadiumId);

        Task<List<Fee>> GetFeesByMonthYearAsync(int month, int year);

        Task<Fee?> UploadBillImage(UploadBillImageDTO uploadBillImageDTO);

        IQueryable<Fee> QueryFees();
    }
}
