using BookingAPI.DTOs;
using BookingAPI.Models;

namespace BookingAPI.Services.Interface
{
        public interface IBookingService
        {
                Task<IEnumerable<BookingReadDto>> GetAllBookingsAsync();
                Task<BookingReadDto?> GetBookingByIdAsync(int id);
                Task<BookingReadDto> CreateBookingAsync(BookingCreateDto bookingCreateDto);
                Task<BookingUpdateDto?> UpdateBookingAsync(int id, BookingUpdateDto bookingUpdateDto);
                Task<bool> DeleteBookingAsync(int id);
                Task<bool> BookingExistsAsync(int id);
                IQueryable<Booking> GetAllBookingsAsQueryable();
                Task<IEnumerable<BookingReadDto>> GetBookingsByDateRangeAndHourAsync(int year, int month, IEnumerable<int> days, TimeSpan startTime, TimeSpan endTime);
                Task<IEnumerable<BookingReadDto>> GetBookingsByCourtIdsAndHourAsync(IEnumerable<int> courtIds, int year, int month, TimeSpan startTime, TimeSpan endTime);
                Task<MonthlyBookingReadDto> CreateMonthlyBookingAsync(int userId, MonthlyBookingCreateDto monthlyBookingCreateDto);
                IQueryable<MonthlyBooking> GetAllMonthlyBookingsAsQueryable();
                Task<MonthlyBookingUpdateDto?> UpdateMonthlyBookingAsync(int id, MonthlyBookingUpdateDto updateDto);
                Task<bool> CheckSlotsAvailabilityAsync(List<BookingSlotRequest> requestedSlots);
                Task AutoAcceptBookingByIdAsync(int bookingId);
                Task AutoCompleteBookingsAsync();
                Task<RevenueStatisticDto> GetRevenueStatisticsAsync(int year, int? month, int? day, IEnumerable<int> stadiumIds);
                Task<IEnumerable<BookingReadDto>> GetBookingsByStadiumsAndDateAsync( IEnumerable<int> stadiumIds, int? year, int? month, int? day);
                Task<IEnumerable<StadiumRevenueDto>> GetRevenueByStadiumsAsync(List<int> stadiumIds, int year, int month);
                Task<RichStadiumKpiDto> GetKpiForStadiumsAsync(List<int> stadiumIds);
                Task<BookingStatisticsDto> GetBookingStatisticsAsync();
                Task<bool> CheckUserHasCompletedBookingsAsync(int userId, int stadiumId);
        }
}
