using BookingAPI.DTOs;
using BookingAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingReadDto>>> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingReadDto>> GetBooking(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost("{userId}")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<BookingReadDto>> CreateBooking(int userId, BookingCreateDto bookingCreateDto)
        {
            try
            {
                bookingCreateDto.UserId = userId;
                var createdBooking = await _bookingService.CreateBookingAsync(bookingCreateDto);
                return CreatedAtAction(
                    nameof(GetBooking),
                    new { id = createdBooking.Id },
                    createdBooking);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating booking: {ex.Message}");
            }
        }

        [HttpPost("by-owner")]
        [Authorize(Roles = "StadiumManager")] // Bảo vệ cho chủ sân hoặc admin
        public async Task<ActionResult<BookingReadDto>> CreateBookingByOwner([FromBody] BookingCreateDto bookingCreateDto)
        {
            try
            {
                var createdBooking = await _bookingService.CreateBookingAsync(bookingCreateDto);

                // Trả về kết quả thành công
                return Ok(createdBooking);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating booking by owner: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookingUpdateDto>> UpdateBooking(int id, BookingUpdateDto bookingUpdateDto)
        {
            var updatedBooking = await _bookingService.UpdateBookingAsync(id, bookingUpdateDto);
            if (updatedBooking == null)
            {
                return NotFound();
            }
            return Ok(updatedBooking);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _bookingService.DeleteBookingAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("filterbydateandhour")]
        public async Task<ActionResult<IEnumerable<BookingReadDto>>> GetBookingsByDateRangeAndHour([FromQuery] int year, [FromQuery] int month, [FromQuery] List<int> days, [FromQuery] string startTime, [FromQuery] string endTime)
        {
            try
            {
                // Chuyển đổi chuỗi thời gian (ví dụ: "15:00") sang TimeSpan
                if (!TimeSpan.TryParse(startTime, out var startTs) || !TimeSpan.TryParse(endTime, out var endTs))
                {
                    return BadRequest("Invalid time format. Use HH:mm.");
                }

                var bookings = await _bookingService.GetBookingsByDateRangeAndHourAsync(year, month, days, startTs, endTs);

                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("filterbycourtandhour")]
        public async Task<ActionResult<IEnumerable<BookingReadDto>>> GetBookingsByCourtAndHour([FromQuery] List<int> courtIds, [FromQuery] int year, [FromQuery] int month, [FromQuery] string startTime, [FromQuery] string endTime)
        {
            try
            {
                if (courtIds == null || !courtIds.Any())
                {
                    return BadRequest("Court IDs must be provided.");
                }

                if (!TimeSpan.TryParse(startTime, out var startTs) || !TimeSpan.TryParse(endTime, out var endTs))
                {
                    return BadRequest("Invalid time format. Use HH:mm.");
                }

                var bookings = await _bookingService.GetBookingsByCourtIdsAndHourAsync(courtIds, year, month, startTs, endTs);

                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost("monthly/{userId}")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<MonthlyBookingReadDto>> CreateMonthlyBooking(int userId, MonthlyBookingCreateDto monthlyBookingCreateDto)
        {
            try
            {
                var createdMonthlyBooking = await _bookingService.CreateMonthlyBookingAsync(userId, monthlyBookingCreateDto);
                return Ok(createdMonthlyBooking);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating monthly booking: {ex.Message}");
            }
        }

        [HttpPut("monthly/{id}")]
        public async Task<ActionResult<MonthlyBookingUpdateDto>> UpdateMonthlyBooking(int id, MonthlyBookingUpdateDto monthlyBookingUpdateDto)
        {
            try
            {
                var updated = await _bookingService.UpdateMonthlyBookingAsync(id, monthlyBookingUpdateDto);

                if (updated == null)
                {
                    return NotFound($"Monthly booking with id {id} not found.");
                }

                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating monthly booking: {ex.Message}");
            }
        }

        [HttpPost("checkAvailability")]
        public async Task<IActionResult> CheckAvailability([FromBody] List<BookingSlotRequest> requestedSlots)
        {
            if (requestedSlots == null || !requestedSlots.Any())
            {
                return BadRequest(new { message = "Danh sách cần kiểm tra không được để trống." });
            }

            try
            {
                bool hasConflict = await _bookingService.CheckSlotsAvailabilityAsync(requestedSlots);

                if (hasConflict)
                {
                    // Nếu có trùng, trả về lỗi 409 Conflict
                    return Conflict(new { message = "Một hoặc nhiều khung giờ bạn chọn đã có người khác đặt." });
                }

                // Nếu không trùng, trả về 200 OK
                return Ok(new { message = "Tất cả các khung giờ đều hợp lệ." });
            }
            catch (Exception ex)
            {
                // Bắt các lỗi không mong muốn từ tầng service/repository
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("statistics")]
        public async Task<ActionResult<RevenueStatisticDto>> GetRevenueStatistics([FromQuery] int? year, [FromQuery] int? month, [FromQuery] int? day, [FromQuery] List<int>? stadiumIds)
        {
            try
            {
                // Nếu không có năm được cung cấp, mặc định lấy năm hiện tại
                int targetYear = year ?? DateTime.UtcNow.Year;

                var statistics = await _bookingService.GetRevenueStatisticsAsync(targetYear, month, day, stadiumIds);
                return Ok(statistics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("by-stadiums-and-date")]
        public async Task<ActionResult<IEnumerable<BookingReadDto>>> GetBookingsByStadiumsAndDate(
            [FromQuery] List<int> stadiumIds, 
            [FromQuery] int? year,
            [FromQuery] int? month,
            [FromQuery] int? day)
        {
            if (stadiumIds == null || !stadiumIds.Any())
            {
                return BadRequest("Stadium IDs must be provided.");
            }

            try
            {
                var bookings = await _bookingService.GetBookingsByStadiumsAndDateAsync(stadiumIds, year, month, day);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("revenue-by-stadiums")]
        public async Task<ActionResult<IEnumerable<StadiumRevenueDto>>> GetRevenueByStadiums([FromBody] RevenueRequestDto request)
        {
            try
            {
                var revenueData = await _bookingService.GetRevenueByStadiumsAsync(request.StadiumIds, request.Year, request.Month);
                return Ok(revenueData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpGet("check-completed/{userId}")]
        [Authorize] // Đảm bảo endpoint này được bảo vệ và có thể nhận userId từ Ocelot
        public async Task<ActionResult<bool>> CheckUserHasCompletedBookings(int userId)
        {
            try
            {
                // userId này đã được Ocelot trích xuất từ token và truyền vào
                var hasCompleted = await _bookingService.CheckUserHasCompletedBookingsAsync(userId);
        
                // Trả về kết quả boolean (true hoặc false)
                return Ok(hasCompleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}