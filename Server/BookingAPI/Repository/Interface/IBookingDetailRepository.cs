using BookingAPI.DTOs;
using BookingAPI.Models;

namespace BookingAPI.Repository.Interface
{
    public interface IBookingDetailRepository
    {
        Task<IEnumerable<BookingDetail>> GetBookingDetailsByBookingIdAsync(int bookingId);
        Task<BookingDetail?> GetBookingDetailByIdAsync(int id);
        Task<BookingDetail> CreateBookingDetailAsync(BookingDetail bookingDetail);
        Task<BookingDetail> UpdateBookingDetailAsync(BookingDetail bookingDetail);
        Task<bool> DeleteBookingDetailAsync(int id);
        Task<bool> BookingDetailExistsAsync(int id);
        Task<bool> SaveChangesAsync();
        Task<bool> AreSlotsConflictingAsync(List<BookingSlotRequest> requestedSlots);
    }
}
