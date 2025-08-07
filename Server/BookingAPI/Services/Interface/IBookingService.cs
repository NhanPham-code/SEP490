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
    }
}
