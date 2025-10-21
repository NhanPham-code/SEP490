﻿using BookingAPI.Data;
using BookingAPI.DTOs;
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

        public async Task<List<Booking>> GetBookingsForStatisticsAsync(int year, int? month, int? day, IEnumerable<int>? stadiumIds = null)
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
            
            if (stadiumIds != null && stadiumIds.Any())
            {
                // Giả định Booking có trường StadiumId kiểu int (đã xác nhận từ Booking.cs)
                query = query.Where(b => stadiumIds.Contains(b.StadiumId));
            }

            return await query.ToListAsync();
        }

        public async Task<List<Booking>> GetBookingsForStatisticsAsync(IEnumerable<int> years, IEnumerable<int>? stadiumIds = null)
        {
            var query = _context.Bookings
                .AsNoTracking()
                .Where(b => years.Contains(b.Date.Year)); // Giữ nguyên việc lọc theo nhiều năm

            // Áp dụng bộ lọc theo danh sách sân
            if (stadiumIds != null && stadiumIds.Any())
            {
                // Giả định Booking có trường StadiumId kiểu int (đã xác nhận từ Booking.cs)
                query = query.Where(b => stadiumIds.Contains(b.StadiumId));
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByStadiumsAndDateAsync(IEnumerable<int> stadiumIds, int? year, int? month, int? day)
        {
            var query = _context.Bookings
                .Include(b => b.BookingDetails)
                .Include(b => b.MonthlyBooking)
                .Where(b => stadiumIds.Contains(b.StadiumId));

            if (year.HasValue)
            {
                query = query.Where(b => b.Date.Year == year.Value);
            }
            if (month.HasValue)
            {
                query = query.Where(b => b.Date.Month == month.Value);
            }
            if (day.HasValue)
            {
                query = query.Where(b => b.Date.Day == day.Value);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<StadiumRevenueDto>> GetRevenueByStadiumsAsync(List<int> stadiumIds, int year, int month)
        {
            // Tạo khoảng ngày để tối ưu index
            var startDate = new DateTime(year, month, 1);
            var endDate = startDate.AddMonths(1);

            var query = _context.Bookings
                .AsNoTracking()
                .Where(b =>
                    stadiumIds.Contains(b.StadiumId) &&      // Lọc theo danh sách sân
                    b.Date >= startDate && b.Date < endDate && // Lọc theo tháng/năm của ngày chơi (không phải ngày tạo booking)
                    b.Status == "Completed");                // Chỉ tính booking đã hoàn thành

            var result = await query
                .GroupBy(b => b.StadiumId) // Nhóm theo từng sân
                .Select(g => new StadiumRevenueDto
                {
                    StadiumId = g.Key,
                    TotalRevenue = g.Sum(b => b.OriginalPrice ?? 0) // Tính tổng doanh thu cho mỗi sân (tính theo giá gốc trước khi trừ mã giảm giá)
                })
                .ToListAsync();

            // Đảm bảo trả về 0 cho các sân không có doanh thu trong tháng
            var allStadiumsResult = stadiumIds.Select(id =>
                result.FirstOrDefault(r => r.StadiumId == id) ?? new StadiumRevenueDto { StadiumId = id, TotalRevenue = 0 }
            ).ToList();

            return allStadiumsResult;
        }
    }
}
