using BookingAPI.DTOs;
using BookingAPI.Services.Interface;
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

        [HttpPost]
        public async Task<ActionResult<BookingReadDto>> CreateBooking(BookingCreateDto bookingCreateDto)
        {
            try
            {
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
    }
}

