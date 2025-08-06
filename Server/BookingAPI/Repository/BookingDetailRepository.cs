using BookingAPI.Data;
using BookingAPI.Models;
using BookingAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Repository
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        private readonly BookingDbContext _context;

        public BookingDetailRepository(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookingDetail>> GetBookingDetailsByBookingIdAsync(int bookingId)
        {
            return await _context.BookingDetails
                .Where(bd => bd.BookingId == bookingId)
                .ToListAsync();
        }

        public async Task<BookingDetail?> GetBookingDetailByIdAsync(int id)
        {
            return await _context.BookingDetails.FindAsync(id);
        }

        public async Task<BookingDetail> CreateBookingDetailAsync(BookingDetail bookingDetail)
        {
            await _context.BookingDetails.AddAsync(bookingDetail);
            await SaveChangesAsync();
            return bookingDetail;
        }

        public async Task<BookingDetail> UpdateBookingDetailAsync(BookingDetail bookingDetail)
        {
            _context.Entry(bookingDetail).State = EntityState.Modified;
            await SaveChangesAsync();
            return bookingDetail;
        }

        public async Task<bool> DeleteBookingDetailAsync(int id)
        {
            var bookingDetail = await _context.BookingDetails.FindAsync(id);
            if (bookingDetail == null) return false;

            _context.BookingDetails.Remove(bookingDetail);
            return await SaveChangesAsync();
        }

        public async Task<bool> BookingDetailExistsAsync(int id)
        {
            return await _context.BookingDetails.AnyAsync(bd => bd.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
