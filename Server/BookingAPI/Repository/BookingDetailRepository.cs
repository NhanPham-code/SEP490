using System.Linq;
using BookingAPI.Data;
using BookingAPI.DTOs;
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

        // --- PHƯƠNG THỨC ĐƯỢC CẬP NHẬT ---
        /// <summary>
        /// Kiểm tra xem các slot yêu cầu có bị trùng với các booking đã tồn tại không.
        /// Chỉ kiểm tra các booking có trạng thái là "pending" hoặc "confirmed".
        /// </summary>
        /// <param name="requestedSlots">Danh sách các slot (CourtId, StartTime, EndTime) cần kiểm tra.</param>
        /// <returns>Danh sách các BookingDetail bị trùng lặp, nếu không có trả về danh sách rỗng.</returns>
        // --- PHƯƠНG THỨC ĐÃ ĐƯỢC TỐI ƯU ĐỂ TRẢ VỀ TRUE/FALSE ---
        public async Task<bool> AreSlotsConflictingAsync(List<BookingSlotRequest> requestedSlots)
        {
            if (requestedSlots == null || !requestedSlots.Any())
            {
                return false; // Không có gì để check, không có xung đột
            }

            var validBookingStatuses = new List<string> { "pending", "accepted", "waiting" };
            var courtIds = requestedSlots.Select(r => r.CourtId).Distinct().ToList();

            // Lấy tất cả các lượt đặt có khả năng bị trùng về server
            var potentiallyConflictingDbSlots = await _context.BookingDetails
                .Include(bd => bd.Booking)
                .Where(bd =>
                    courtIds.Contains(bd.CourtId) &&
                    bd.Booking != null && validBookingStatuses.Contains(bd.Booking.Status)
                )
                .ToListAsync();

            // Nếu không có lượt đặt nào trong DB thì chắc chắn không trùng
            if (!potentiallyConflictingDbSlots.Any())
            {
                return false;
            }

            // Duyệt qua từng slot yêu cầu và kiểm tra
            foreach (var requestedSlot in requestedSlots)
            {
                // Dùng .Any() để kiểm tra sự tồn tại của xung đột.
                // Nó sẽ dừng ngay khi tìm thấy kết quả đầu tiên, rất hiệu quả.
                bool isConflicting = potentiallyConflictingDbSlots.Any(dbSlot =>
                    dbSlot.CourtId == requestedSlot.CourtId &&
                    requestedSlot.StartTime < dbSlot.EndTime &&
                    requestedSlot.EndTime > dbSlot.StartTime
                );

                // Nếu tìm thấy bất kỳ một xung đột nào, lập tức trả về true
                if (isConflicting)
                {
                    return true;
                }
            }

            // Nếu vòng lặp kết thúc mà không tìm thấy xung đột nào, trả về false
            return false;
        }

    }
}
