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
    }
}
