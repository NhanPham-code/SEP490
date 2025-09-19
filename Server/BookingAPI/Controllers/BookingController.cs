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
    }
}

