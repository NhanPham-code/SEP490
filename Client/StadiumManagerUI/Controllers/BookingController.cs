using System.Text.Json;
using DTOs.BookingDTO;
using DTOs.BookingDTO.ViewModel;
using DTOs.StadiumDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using StadiumManagerUI.Helpers;

namespace StadiumManagerUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IBookingService _bookingService;
        private readonly IStadiumService _stadiumService;
        private readonly IDiscountService _discountService;

        public BookingController(
            ITokenService tokenService,
            IBookingService bookingService,
            IStadiumService stadiumService,
            IDiscountService discountService)
        {
            _tokenService = tokenService;
            _bookingService = bookingService;
            _stadiumService = stadiumService;
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> BookingManager()
        {
            Console.WriteLine("Starting BookingManager action");

            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
                return RedirectToAction("Login", "Account");

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            Console.WriteLine($"Processing request for user ID: {userId}");

            var viewModel = new BookingManagementViewModel
            {
                DailyBookings = new List<BookingReadDto>(),
                MonthlyBookings = new List<MonthlyBookingReadDto>()
            };

            // 1. Fetch stadiums owned by the user
            string stadiumFilter = $"&$filter=CreatedBy eq {userId}";
            Console.WriteLine($"Fetching stadiums with filter: {stadiumFilter}");

            var stadiumsJson = await _stadiumService.SearchStadiumAsync(stadiumFilter);
            Console.WriteLine($"Stadium API response length: {stadiumsJson?.Length ?? 0}");

            var stadiums = new List<ReadStadiumDTO>();
            if (!string.IsNullOrEmpty(stadiumsJson))
            {
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    // Register the TimeSpan converter
                    options.Converters.Add(new Iso8601TimeSpanConverter());

                    using (JsonDocument doc = JsonDocument.Parse(stadiumsJson))
                    {
                        if (doc.RootElement.TryGetProperty("value", out JsonElement valueElement))
                        {
                            stadiums = JsonSerializer.Deserialize<List<ReadStadiumDTO>>(
                                valueElement.GetRawText(), options
                            ) ?? new List<ReadStadiumDTO>();
                        }
                    }

                    Console.WriteLine($"Found {stadiums.Count} stadiums for user");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error parsing stadiums JSON: {ex.Message}");
                    return View("Error", new { success = false, message = "Failed to load stadium data" });
                }
            }

            if (stadiums.Any())
            {
                // 2. Create filter for booking queries based on stadium IDs
                var stadiumIds = stadiums.Select(s => s.Id);
                var filterClauses = stadiumIds.Select(id => $"StadiumId eq {id}");
                string bookingFilter = string.Join(" or ", filterClauses);
                Console.WriteLine($"Booking filter: {bookingFilter}");

                // 3. Fetch daily bookings (excluding monthly bookings)
                string dailyBookingQueryString =
                    $"?$filter=({bookingFilter}) and MonthlyBookingId eq null&$expand=BookingDetails";
                Console.WriteLine($"Fetching daily bookings with query: {dailyBookingQueryString}");

                try
                {
                    viewModel.DailyBookings = await _bookingService.GetBookingAsync(
                        accessToken, dailyBookingQueryString);
                    Console.WriteLine($"Found {viewModel.DailyBookings.Count} daily bookings");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching daily bookings: {ex.Message}");
                }

                // 4. Fetch monthly bookings
                string monthlyBookingQueryString = $"?$filter={bookingFilter}";
                Console.WriteLine($"Fetching monthly bookings with query: {monthlyBookingQueryString}");

                try
                {
                    viewModel.MonthlyBookings = await _bookingService.GetMonthlyBookingAsync(
                        accessToken, monthlyBookingQueryString);
                    Console.WriteLine($"Found {viewModel.MonthlyBookings.Count} monthly bookings");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching monthly bookings: {ex.Message}");
                    // Continue with partial data rather than failing completely
                }
            }
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine(JsonSerializer.Serialize(viewModel));
            ViewBag.Stadiums = stadiums;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingUpdateDto dto)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized(new { message = "Token not found" });

            var updated = await _bookingService.UpdateBookingAsync(id, dto, accessToken);
            if (updated == null)
                return BadRequest(new { message = "Update booking failed" });

            return Json(new { success = true, booking = updated });
        }

        // === Update monthly booking ===
        [HttpPost]
        public async Task<IActionResult> UpdateMonthlyBooking(int id, [FromBody] MonthlyBookingUpdateDto dto)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized(new { message = "Token not found" });

            var updated = await _bookingService.UpdateMonthlyBookingAsync(id, dto, accessToken);
            if (updated == null)
                return BadRequest(new { message = "Update monthly booking failed" });

            return Json(new { success = true, booking = updated });
        }
    }
}