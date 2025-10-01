using BookingAPI.Data;
using BookingAPI.Models;
using BookingAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _context;

        public BookingRepository(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.BookingDetails)
                .ToListAsync();
        }

        public async Task<Booking?> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.BookingDetails)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> UpdateBookingAsync(Booking booking)
        {
            booking.UpdatedAt = DateTime.Now;
            _context.Entry(booking).State = EntityState.Modified;
            await SaveChangesAsync();
            return booking;
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return false;

            _context.Bookings.Remove(booking);
            return await SaveChangesAsync();
        }

        public async Task<bool> BookingExistsAsync(int id)
        {
            return await _context.Bookings.AnyAsync(b => b.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<Booking> GetAllBookingsAsQueryable()
        {
            return _context.Bookings
                .Include(b => b.BookingDetails)
                .AsQueryable();
        }

        // Trong BookingRepository.cs
        public async Task<IEnumerable<Booking>> GetBookingsByDateRangeAndHourAsync(int year, int month, IEnumerable<int> days, TimeSpan startTime, TimeSpan endTime)
        {
            // *** THAY ĐỔI QUAN TRỌNG Ở ĐÂY ***
            var validStatuses = new List<string> { "pending", "accepted", "waiting", "completed" };

            var query = _context.Bookings
                .Include(b => b.BookingDetails)
                .Where(b => b.Date.Year == year && b.Date.Month == month && validStatuses.Contains(b.Status));

            // Lọc theo danh sách ngày
            if (days != null && days.Any())
            {
                query = query.Where(b => days.Contains(b.Date.Day));
            }

            // Lọc theo khung giờ trùng lặp trên BookingDetails
            query = query.Where(b =>
                b.BookingDetails.Any(bd =>
                    startTime < bd.EndTime.TimeOfDay && endTime > bd.StartTime.TimeOfDay));

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByCourtIdsAndHourAsync(IEnumerable<int> courtIds, int year, int month, TimeSpan startTime, TimeSpan endTime)
        {
            // *** THAY ĐỔI QUAN TRỌNG Ở ĐÂY ***
            var validStatuses = new List<string> { "pending", "accepted", "waiting", "completed" };

            var query = _context.Bookings
                .Include(b => b.BookingDetails)
                .Where(b => b.Date.Year == year && b.Date.Month == month && validStatuses.Contains(b.Status));

            query = query.Where(b => b.BookingDetails.Any(bd =>
                courtIds.Contains(bd.CourtId) &&
                startTime < bd.EndTime.TimeOfDay &&
                endTime > bd.StartTime.TimeOfDay));

            return await query.ToListAsync();
        }

        public async Task<List<Booking>> GetBookingsForStatisticsAsync(int year, int? month, int? day)
        {
            var query = _context.Bookings.AsNoTracking().Where(b => b.Date.Year == year);

            if (month.HasValue)
            {
                query = query.Where(b => b.Date.Month == month.Value);
            }

            if (day.HasValue)
            {
                query = query.Where(b => b.Date.Day == day.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<List<Booking>> GetBookingsForStatisticsAsync(IEnumerable<int> years)
        {
            return await _context.Bookings
                .AsNoTracking()
                .Where(b => years.Contains(b.Date.Year))
                .ToListAsync();
        }
    }
}
