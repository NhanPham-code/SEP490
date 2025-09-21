using BookingAPI.Models;

namespace BookingAPI.Repository.Interface
{
    public interface IMonthlyBookingRepository
    {
        Task<MonthlyBooking> CreateMonthlyBookingAsync(MonthlyBooking monthlyBooking);
    }
}
