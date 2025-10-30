using AutoMapper;
using BookingAPI.DTOs;
using BookingAPI.Models;
using BookingAPI.Repository;
using BookingAPI.Repository.Interface;
using BookingAPI.Services.Interface;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingDetailRepository _bookingDetailRepository;
        private readonly IMonthlyBookingRepository _monthlyBookingRepository;
        private readonly IMapper _mapper;

        public BookingService(
            IBookingRepository bookingRepository,
            IBookingDetailRepository bookingDetailRepository,
            IMonthlyBookingRepository monthlyBookingRepository,
            IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _bookingDetailRepository = bookingDetailRepository;
            _monthlyBookingRepository = monthlyBookingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingReadDto>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllBookingsAsync();
            return _mapper.Map<IEnumerable<BookingReadDto>>(bookings);
        }

        public async Task<BookingReadDto?> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(id);
            return booking == null ? null : _mapper.Map<BookingReadDto>(booking);
        }

        public async Task<BookingReadDto> CreateBookingAsync(BookingCreateDto bookingCreateDto)
        {
            var booking = _mapper.Map<Booking>(bookingCreateDto);

            // Map booking details
            /*foreach (var detailDto in bookingCreateDto.BookingDetails)
            {
                var bookingDetail = _mapper.Map<BookingDetail>(detailDto);
                booking.BookingDetails.Add(bookingDetail);
            }*/

            var createdBooking = await _bookingRepository.CreateBookingAsync(booking);

            var jobId = BackgroundJob.Schedule(() => AutoAcceptBookingByIdAsync(createdBooking.Id), TimeSpan.FromMinutes(5));

            Console.WriteLine($"Đã thêm job {jobId} để tự động check booking {createdBooking.Id} trong 5 phút");
            return _mapper.Map<BookingReadDto>(createdBooking);
        }

        public async Task<BookingUpdateDto?> UpdateBookingAsync(int id, BookingUpdateDto bookingUpdateDto)
        {
            var existingBooking = await _bookingRepository.GetBookingByIdAsync(id);
            if (existingBooking == null) return null;

            _mapper.Map(bookingUpdateDto, existingBooking);

            // Update booking details
            /*            existingBooking.BookingDetails.Clear();
                        foreach (var detailDto in bookingUpdateDto.BookingDetails)
                        {
                            var bookingDetail = _mapper.Map<BookingDetail>(detailDto);
                            bookingDetail.BookingId = id;
                            existingBooking.BookingDetails.Add(bookingDetail);
                        }*/

            var updatedBooking = await _bookingRepository.UpdateBookingAsync(existingBooking);
            return _mapper.Map<BookingUpdateDto>(updatedBooking);
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            return await _bookingRepository.DeleteBookingAsync(id);
        }

        public async Task<bool> BookingExistsAsync(int id)
        {
            return await _bookingRepository.BookingExistsAsync(id);
        }

        // OData get all bookings queryable
        public IQueryable<Booking> GetAllBookingsAsQueryable()
        {
            return _bookingRepository.GetAllBookingsAsQueryable();
        }

        public async Task<IEnumerable<BookingReadDto>> GetBookingsByDateRangeAndHourAsync(int year, int month, IEnumerable<int> days, TimeSpan startTime, TimeSpan endTime)
        {
            var bookings = await _bookingRepository.GetBookingsByDateRangeAndHourAsync(year, month, days, startTime, endTime);

            return _mapper.Map<IEnumerable<BookingReadDto>>(bookings);
        }

        public async Task<IEnumerable<BookingReadDto>> GetBookingsByCourtIdsAndHourAsync(IEnumerable<int> courtIds, int year, int month, TimeSpan startTime, TimeSpan endTime)
        {
            var bookings = await _bookingRepository.GetBookingsByCourtIdsAndHourAsync(courtIds, year, month, startTime, endTime);

            return _mapper.Map<IEnumerable<BookingReadDto>>(bookings);
        }

        public async Task<MonthlyBookingReadDto> CreateMonthlyBookingAsync(int userId, MonthlyBookingCreateDto monthlyBookingCreateDto)
        {
            if (!TimeSpan.TryParseExact(monthlyBookingCreateDto.StartTime, "hh\\:mm", CultureInfo.InvariantCulture, out var startTime) ||
                !TimeSpan.TryParseExact(monthlyBookingCreateDto.EndTime, "hh\\:mm", CultureInfo.InvariantCulture, out var endTime))
            {
                throw new ArgumentException("Invalid time format. Use HH:mm.");
            }

            var monthlyBooking = _mapper.Map<MonthlyBooking>(monthlyBookingCreateDto);
            monthlyBooking.UserId = userId; // gán từ tham số
            monthlyBooking.StartTime = startTime;
            monthlyBooking.EndTime = endTime;
            var hoursPerDay = (endTime - startTime).TotalHours;
            monthlyBooking.TotalHour = (int)(hoursPerDay * monthlyBookingCreateDto.Dates.Count);

            foreach (var day in monthlyBookingCreateDto.Dates)
            {
                var bookingDate = new DateTime(monthlyBookingCreateDto.Year, monthlyBookingCreateDto.Month, day);

                var booking = new Booking
                {
                    UserId = userId,
                    StadiumId = monthlyBooking.StadiumId,
                    DiscountId = monthlyBooking.DiscountId,
                    Date = bookingDate,
                    OriginalPrice = monthlyBooking.OriginalPrice / monthlyBookingCreateDto.Dates.Count,
                    TotalPrice = monthlyBooking.TotalPrice / monthlyBookingCreateDto.Dates.Count,
                    PaymentMethod = monthlyBooking.PaymentMethod,
                    Note = monthlyBooking.Note,
                    Status = "pending",
                };

                foreach (var courtId in monthlyBookingCreateDto.CourtIds)
                {
                    booking.BookingDetails.Add(new BookingDetail
                    {
                        CourtId = courtId,
                        StartTime = bookingDate.Add(startTime),
                        EndTime = bookingDate.Add(endTime)
                    });
                }

                monthlyBooking.Bookings.Add(booking);
            }

            var createdMonthlyBooking = await _monthlyBookingRepository.CreateMonthlyBookingAsync(monthlyBooking);

            var readDto = _mapper.Map<MonthlyBookingReadDto>(createdMonthlyBooking);
            readDto.BookingIds = createdMonthlyBooking.Bookings.Select(b => b.Id).ToList();

            return readDto;
        }

        public IQueryable<MonthlyBooking> GetAllMonthlyBookingsAsQueryable()
        {
            return _monthlyBookingRepository.GetAllMonthlyBookingsAsQueryable();
        }

        public async Task<MonthlyBookingUpdateDto?> UpdateMonthlyBookingAsync(int id, MonthlyBookingUpdateDto updateDto)
        {
            var existingMonthlyBooking = await _monthlyBookingRepository
                .GetAllMonthlyBookingsAsQueryable()
                .FirstOrDefaultAsync(mb => mb.Id == id);

            if (existingMonthlyBooking == null)
                return null;

            // Map từ DTO sang entity (AutoMapper sẽ update các field có giá trị)
            _mapper.Map(updateDto, existingMonthlyBooking);

            var updatedMonthlyBooking = await _monthlyBookingRepository.UpdateMonthlyBookingAsync(existingMonthlyBooking);
            return _mapper.Map<MonthlyBookingUpdateDto>(updatedMonthlyBooking);
        }

        public async Task<bool> CheckSlotsAvailabilityAsync(List<BookingSlotRequest> requestedSlots)
        {
            // Đơn giản là gọi phương thức từ repository đã được tạo trước đó
            return await _bookingDetailRepository.AreSlotsConflictingAsync(requestedSlots);
        }

        public async Task AutoAcceptBookingByIdAsync(int bookingId)
        {
            Console.WriteLine($"Bắt đầu check Booking: {bookingId}");

            var booking = await _bookingRepository.GetBookingByIdAsync(bookingId);

            if (booking != null && "waiting".Equals(booking.Status, StringComparison.OrdinalIgnoreCase))
            {

                booking.Status = "payfail";

                try
                {

                    await _bookingRepository.UpdateBookingAsync(booking);
                    Console.WriteLine($"Booking {bookingId} thanh toán thất bại");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi duyệt Booking {bookingId}: {ex.Message}");
                    throw;
                }
            }
            else
            {
                var currentStatus = booking?.Status ?? "Không tìm thấy trạng thái";
                Console.WriteLine($"Bỏ qua Booking có trạng thái hợp lệ");
            }
        }
        public async Task AutoCompleteBookingsAsync()
        {
            Console.WriteLine("Bắt đầu chuyển cập nhật trạng thái completed");

            var now = DateTime.UtcNow;


            var bookingsToComplete = await _bookingRepository.GetAllBookingsAsQueryable()
                .Where(b => b.Status == "accepted" && b.BookingDetails.Any(bd => bd.EndTime < now))
                .ToListAsync();

            if (bookingsToComplete == null || !bookingsToComplete.Any())
            {
                Console.WriteLine("Không có booking phù hợp");
                return;
            }

            Console.WriteLine($"Đã tìm thấy {bookingsToComplete.Count} booking để chuyển về completed");

            int completedCount = 0;
            foreach (var booking in bookingsToComplete)
            {
                booking.Status = "completed";
                booking.Note = (booking.Note ?? "") + " Tự động cập nhật completed bởi hệ thống";

                try
                {
                    await _bookingRepository.UpdateBookingAsync(booking);
                    completedCount++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Lỗi khi complete booking ID {booking.Id}: {ex.Message}");
                }
            }

            if (completedCount > 0)
            {
                Console.WriteLine($" Cập nhật thành công {completedCount} booking");
            }
        }

        public async Task<RevenueStatisticDto> GetRevenueStatisticsAsync(int year, int? month, int? day, IEnumerable<int>? stadiumIds = null)
        {
            var nowYear = DateTime.UtcNow.Year;

            // Xác định các năm cần lấy dữ liệu
            List<int> yearsToFetch;
            if (year == nowYear)
            {
                // Nếu là năm hiện tại: chỉ lấy 2 năm trước và năm hiện tại
                yearsToFetch = new List<int> { year - 2, year - 1, year };
            }
            else
            {
                // Nếu là năm khác: lấy 2 năm trước, năm hiện tại, 1 năm sau
                yearsToFetch = new List<int> { year - 2, year - 1, year, year + 1 };
            }

            // Lấy booking của các năm này (bạn cần sửa repository cho phép truyền IEnumerable<int>)
            var bookingsForChart = await _bookingRepository.GetBookingsForStatisticsAsync(yearsToFetch, stadiumIds);

            // Lọc booking cho phần thống kê (chỉ năm đang xem)
            var bookingsForStats = bookingsForChart.Where(b => b.Date.Year == year).ToList();
            if (month.HasValue)
            {
                bookingsForStats = bookingsForStats.Where(b => b.Date.Month == month.Value).ToList();
            }
            if (day.HasValue)
            {
                bookingsForStats = bookingsForStats.Where(b => b.Date.Day == day.Value).ToList();
            }

            var totalBookingsCount = bookingsForStats.Count;
            var completedBookings = bookingsForStats.Where(b => b.Status == "completed").ToList();
            var pendingBookingsCount = bookingsForStats.Count(b => b.Status == "waiting");
            var acceptedBookingsCount = bookingsForStats.Count(b => b.Status == "accepted");
            var cancelledBookingsCount = bookingsForStats.Count(b => b.Status == "cancelled");

            var totalRevenue = completedBookings.Sum(b => b.TotalPrice ?? 0);
            var totalOriginalRevenue = completedBookings.Sum(b => b.OriginalPrice ?? 0); 
            var totalCompletedBookings = completedBookings.Count;

            // Dữ liệu cho biểu đồ: mỗi năm là 1 dictionary 12 tháng
            var monthlyRevenueChartData = new Dictionary<int, Dictionary<int, decimal>>();
            foreach (var y in yearsToFetch)
            {
                var revenueByMonth = bookingsForChart
                    .Where(b => b.Date.Year == y && b.Status == "completed")
                    .GroupBy(b => b.Date.Month)
                    .ToDictionary(g => g.Key, g => g.Sum(b => b.TotalPrice ?? 0));
                var fullYearRevenue = new Dictionary<int, decimal>();
                for (int i = 1; i <= 12; i++)
                {
                    fullYearRevenue[i] = revenueByMonth.ContainsKey(i) ? revenueByMonth[i] : 0;
                }
                monthlyRevenueChartData[y] = fullYearRevenue;
            }

            var statisticsDto = new RevenueStatisticDto
            {
                TotalRevenue = totalRevenue,
                TotalOriginalRevenue = totalOriginalRevenue, 
                TotalCompletedBookings = totalCompletedBookings,
                CompletedBookingsPercentage = totalBookingsCount > 0 ? (double)totalCompletedBookings / totalBookingsCount * 100 : 0,
                PendingBookingsCount = pendingBookingsCount,
                AcceptedBookingsCount = acceptedBookingsCount,
                WaitingBookingsPercentage = totalBookingsCount > 0 ? (double)(pendingBookingsCount + acceptedBookingsCount) / totalBookingsCount * 100 : 0,
                CancelledBookingsCount = cancelledBookingsCount,
                CancelledBookingsPercentage = totalBookingsCount > 0 ? (double)cancelledBookingsCount / totalBookingsCount * 100 : 0,
                MonthlyRevenueChartData = monthlyRevenueChartData
            };

            return statisticsDto;
        }

        public async Task<IEnumerable<BookingReadDto>> GetBookingsByStadiumsAndDateAsync(IEnumerable<int> stadiumIds, int? year, int? month, int? day)
        {
            var bookings = await _bookingRepository.GetBookingsByStadiumsAndDateAsync(stadiumIds, year, month, day);
            return _mapper.Map<IEnumerable<BookingReadDto>>(bookings);
        }

        public async Task<IEnumerable<StadiumRevenueDto>> GetRevenueByStadiumsAsync(List<int> stadiumIds, int year, int month)
        {
            return await _bookingRepository.GetRevenueByStadiumsAsync(stadiumIds, year, month);
        }
        
        public async Task<bool> CheckUserHasCompletedBookingsAsync(int userId)
        {
            return await _bookingRepository.HasCompletedBookingsAsync(userId);
        }
    }
}
