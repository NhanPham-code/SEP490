using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.BookingDTO;

namespace Service.Interfaces
{
    public interface IBookingService
    {
        // Lấy lịch sử booking của user hiện tại, cần token để xác thực
        Task<List<BookingReadDto>> GetBookingAsync(string accessToken, string queryString);
        Task<BookingReadDto?> CreateBookingAsync(BookingCreateDto bookingCreateDto, string accessToken);
        Task<BookingReadDto> GetBookingDetailAsync(string accessToken, int bookingId);
        Task<List<BookingReadDto>> GetBookedCourtsAsync(int stadiumId, DateTime startTime, DateTime endTime);
        Task<List<BookingReadDto>> GetBookedCourtsAsync(int stadiumId, DateTime date);
        Task<List<BookingReadDto>> FilterByDateAndHour(int year, int month, List<int> days, int startTime, int endTime);
        Task<List<BookingReadDto>> FilterByCourtAndHour(List<int> courtIds, int year, int month, int startTime, int endTime);
        Task<BookingReadDto?> CreateMonthlyBookingAsync(MonthlyBookingCreateDto bookingDto, string accessToken);
        Task<List<MonthlyBookingReadDto>> GetMonthlyBookingAsync(string accessToken, string queryString);
        Task<MonthlyBookingReadDto?> UpdateMonthlyBookingAsync(int id, MonthlyBookingUpdateDto bookingDto, string accessToken);
        Task<BookingReadDto?> UpdateBookingAsync(int id, BookingUpdateDto bookingDto, string accessToken);
        Task<RevenueStatisticViewModel> GetRevenueStatisticsAsync(string accessToken, int year, int? month, int? day);
    }
}
