using AggregatorPatternAPI.DTOs;

namespace AggregatorPatternAPI.Services
{
    public interface IAggregatorService
    { 
        Task<IEnumerable<StadiumBookingOverviewDto>> GetStadiumsBookingOverviewAsync(int page, int pageSize, int? year, int? month, int? day);
        Task<StadiumManagerDashboardDto?> GetStadiumManagerDashboardAsync(int userId);
        Task<AdminDashboardDto?> GetAdminDashboardAsync();
    }
}
