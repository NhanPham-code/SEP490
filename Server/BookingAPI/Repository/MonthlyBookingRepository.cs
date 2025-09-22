using BookingAPI.Data;
using BookingAPI.Models;
using BookingAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Repository
{
    public class MonthlyBookingRepository : IMonthlyBookingRepository
    {
        private readonly BookingDbContext _context;

        public MonthlyBookingRepository(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<MonthlyBooking> CreateMonthlyBookingAsync(MonthlyBooking monthlyBooking)
        {
            // The service layer will construct the monthlyBooking object with all its related Bookings.
            // We just need to add it to the context. EF Core will handle inserting the parent and all its children.
            await _context.MonthlyBookings.AddAsync(monthlyBooking);
            await _context.SaveChangesAsync();
            return monthlyBooking;
        }

        public IQueryable<MonthlyBooking> GetAllMonthlyBookingsAsQueryable()
        {
            return _context.MonthlyBookings
                .Include(b => b.Bookings)
                .AsQueryable();
        }

        public async Task<MonthlyBooking> UpdateMonthlyBookingAsync(MonthlyBooking monthlyBooking)
        {
            monthlyBooking.UpdatedAt = DateTime.Now; // nếu ông có field UpdatedAt
            _context.Entry(monthlyBooking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return monthlyBooking;
        }

    }
}