using BookingAPI.DTOs;
using BookingAPI.Models;

namespace BookingAPI.Repository.Interface
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking?> GetBookingByIdAsync(int id);
        Task<Booking> CreateBookingAsync(Booking booking);
        Task<Booking> UpdateBookingAsync(Booking booking);
        Task<bool> DeleteBookingAsync(int id);
        Task<bool> BookingExistsAsync(int id);
        Task<bool> SaveChangesAsync();
        IQueryable<Booking> GetAllBookingsAsQueryable();
        Task<IEnumerable<Booking>> GetBookingsByDateRangeAndHourAsync(int year, int month, IEnumerable<int> days, TimeSpan startTime, TimeSpan endTime);
        Task<IEnumerable<Booking>> GetBookingsByCourtIdsAndHourAsync(IEnumerable<int> courtIds, int year, int month, TimeSpan startTime, TimeSpan endTime);
        Task<List<Booking>> GetBookingsForStatisticsAsync(int year, int? month, int? day, IEnumerable<int> stadiumId);
        Task<List<Booking>> GetBookingsForStatisticsAsync(IEnumerable<int> years, IEnumerable<int> stadiumId);
        Task<IEnumerable<Booking>> GetBookingsByStadiumsAndDateAsync( IEnumerable<int> stadiumIds, int? year, int? month, int? day);
        Task<IEnumerable<StadiumRevenueDto>> GetRevenueByStadiumsAsync(List<int> stadiumIds, int year, int month);
        Task<bool> HasCompletedBookingsAsync(int userId, int stadiumId);
    }
}
