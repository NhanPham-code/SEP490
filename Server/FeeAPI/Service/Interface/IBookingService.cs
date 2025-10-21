using FeeAPI.DTOs;

namespace FeeAPI.Service.Interface
{
    public interface IBookingService
    {
        Task<IEnumerable<StadiumRevenueDto>> GetStadiumRevenuesAsync(RevenueRequestDto revenueRequestDto);
    }
}
