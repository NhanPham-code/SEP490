using System.Configuration;
using System.Text.Json;
using DTOs.BookingDTO;
using DTOs.BookingDTO.ViewModel;
using DTOs.Helpers;
using DTOs.StadiumDTO;
using DTOs.UserDTO;
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
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;


        public BookingController(
            ITokenService tokenService,
            IBookingService bookingService,
            IStadiumService stadiumService,
            IDiscountService discountService,
            IUserService userService,
            IConfiguration configuration)
        {
            _tokenService = tokenService;
            _bookingService = bookingService;
            _stadiumService = stadiumService;
            _discountService = discountService;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> BookingManager()
        {

            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
                return RedirectToAction("Login", "Account");

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var viewModel = new BookingManagementViewModel();

            string stadiumFilter = $"&$filter=CreatedBy eq {userId}";
            var stadiumsJson = await _stadiumService.SearchStadiumAsync(stadiumFilter);
            var stadiums = new List<ReadStadiumDTO>();
            if (!string.IsNullOrEmpty(stadiumsJson))
            {
                try
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    options.Converters.Add(new Iso8601TimeSpanConverter());
                    using (JsonDocument doc = JsonDocument.Parse(stadiumsJson))
                    {
                        if (doc.RootElement.TryGetProperty("value", out JsonElement valueElement))
                        {
                            stadiums = JsonSerializer.Deserialize<List<ReadStadiumDTO>>(valueElement.GetRawText(), options) ?? new List<ReadStadiumDTO>();
                        }
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error parsing stadiums JSON: {ex.Message}");
                    return View("Error", new { message = "Failed to load stadium data" });
                }
            }

            if (stadiums.Any())
            {
                var stadiumIds = stadiums.Select(s => s.Id);
                string bookingFilter = string.Join(" or ", stadiumIds.Select(id => $"StadiumId eq {id}"));

                var allBookings = await _bookingService.GetBookingAsync(accessToken, $"?$filter=({bookingFilter})&$expand=BookingDetails") ?? new List<BookingReadDto>();
                var monthlyBookings = await _bookingService.GetMonthlyBookingAsync(accessToken, $"?$filter={bookingFilter}") ?? new List<MonthlyBookingReadDto>();

                var dailyUserIds = allBookings.Where(b => b.MonthlyBookingId == null).Select(b => b.UserId);
                var monthlyUserIds = monthlyBookings.Select(b => b.UserId);
                var allUserIds = dailyUserIds.Concat(monthlyUserIds).Distinct().ToList();

                var users = new List<PublicUserProfileDTO>();
                if (allUserIds.Any())
                {
                    users = await _userService.GetUsersByIdsAsync(allUserIds, accessToken) ?? new List<PublicUserProfileDTO>();
                }
                var userDictionary = users.ToDictionary(u => u.UserId);
                var defaultUser = new PublicUserProfileDTO { FullName = "Người dùng ẩn danh" };

                var dailyBookingsList = allBookings.Where(b => b.MonthlyBookingId == null);
                foreach (var booking in dailyBookingsList)
                {
                    viewModel.DailyBookings.Add(new DailyBookingWithUserViewModel
                    {
                        Booking = booking,
                        User = userDictionary.GetValueOrDefault(booking.UserId, defaultUser)
                    });
                }

                var bookingsInMonthlyPlan = allBookings.Where(b => b.MonthlyBookingId != null).GroupBy(b => b.MonthlyBookingId).ToDictionary(g => g.Key, g => g.ToList());

                foreach (var mb in monthlyBookings)
                {
                    viewModel.MonthlyBookings.Add(new MonthlyBookingWithDetailsViewModel
                    {
                        MonthlyBooking = mb,
                        User = userDictionary.GetValueOrDefault(mb.UserId, defaultUser),
                        Bookings = bookingsInMonthlyPlan.GetValueOrDefault(mb.Id, new List<BookingReadDto>())
                    });
                }
            }

            ViewBag.Stadiums = stadiums;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingUpdateDto dto)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized(new { message = "Token not found" });

            if ("cancelled".Equals(dto.Status, StringComparison.OrdinalIgnoreCase) || "denied".Equals(dto.Status, StringComparison.OrdinalIgnoreCase))
            {
                var cancellationFee = (long)(dto.TotalPrice.GetValueOrDefault());
                if (cancellationFee > 0)
                {
                    HttpContext.Session.SetString("FinalStatus", dto.Status);
                    HttpContext.Session.SetInt32("BookingIdToUpdate", id);
                    HttpContext.Session.SetString("BookingType", "Daily");
                    HttpContext.Session.SetString("AccessToken", accessToken); // Lưu token cho callback

                    var vnpay = new VnPayLibrary();
                    vnpay.AddRequestData("vnp_Version", _configuration["VNPAY:Version"]);
                    vnpay.AddRequestData("vnp_Command", _configuration["VNPAY:Command"]);
                    vnpay.AddRequestData("vnp_TmnCode", _configuration["VNPAY:TmnCode"]);
                    vnpay.AddRequestData("vnp_Amount", (cancellationFee * 100).ToString());
                    vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
                    vnpay.AddRequestData("vnp_CurrCode", _configuration["VNPAY:CurrCode"]);
                    vnpay.AddRequestData("vnp_IpAddr", "127.0.0.1"); // Thay bằng IP thực tế
                    vnpay.AddRequestData("vnp_Locale", _configuration["VNPAY:Locale"]);
                    vnpay.AddRequestData("vnp_OrderInfo", $"Pay cancellation fee for BookingId:{id}");
                    vnpay.AddRequestData("vnp_OrderType", "other");
                    vnpay.AddRequestData("vnp_ReturnUrl", _configuration["VNPAY:ReturnUrl"]);
                    vnpay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString());

                    string paymentUrl = vnpay.CreateRequestUrl(_configuration["VNPAY:Url"], _configuration["VNPAY:HashSecret"]);
                    return Json(new { paymentRequired = true, paymentUrl = paymentUrl });
                }
            }

            var updated = await _bookingService.UpdateBookingAsync(id, dto, accessToken);
            if (updated == null)
                return BadRequest(new { message = "Update booking failed" });

            return Json(new { success = true, booking = updated });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMonthlyBooking(int id, [FromBody] MonthlyBookingUpdateDto dto)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized(new { message = "Token not found" });

            if ("cancelled".Equals(dto.Status, StringComparison.OrdinalIgnoreCase) || "denied".Equals(dto.Status, StringComparison.OrdinalIgnoreCase))
            {
                var cancellationFee = (long)(dto.TotalPrice.GetValueOrDefault());
                if (cancellationFee > 0)
                {
                    HttpContext.Session.SetString("FinalStatus", dto.Status);
                    HttpContext.Session.SetInt32("BookingIdToUpdate", id);
                    HttpContext.Session.SetString("BookingType", "Monthly");
                    HttpContext.Session.SetString("AccessToken", accessToken); // Lưu token cho callback

                    var vnpay = new VnPayLibrary();
                    vnpay.AddRequestData("vnp_Version", _configuration["VNPAY:Version"]);
                    vnpay.AddRequestData("vnp_Command", _configuration["VNPAY:Command"]);
                    vnpay.AddRequestData("vnp_TmnCode", _configuration["VNPAY:TmnCode"]);
                    vnpay.AddRequestData("vnp_Amount", (cancellationFee * 100).ToString());
                    vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
                    vnpay.AddRequestData("vnp_CurrCode", _configuration["VNPAY:CurrCode"]);
                    vnpay.AddRequestData("vnp_IpAddr", "127.0.0.1");
                    vnpay.AddRequestData("vnp_Locale", _configuration["VNPAY:Locale"]);
                    vnpay.AddRequestData("vnp_OrderInfo", $"Pay cancellation fee for MonthlyBookingId:{id}");
                    vnpay.AddRequestData("vnp_OrderType", "other");
                    vnpay.AddRequestData("vnp_ReturnUrl", _configuration["VNPAY:ReturnUrl"]);
                    vnpay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString());

                    string paymentUrl = vnpay.CreateRequestUrl(_configuration["VNPAY:Url"], _configuration["VNPAY:HashSecret"]);
                    return Json(new { paymentRequired = true, paymentUrl = paymentUrl });
                }
            }

            // Nếu không có phí, cập nhật như bình thường
            var updatedMonthlyBooking = await _bookingService.UpdateMonthlyBookingAsync(id, dto, accessToken);
            if (updatedMonthlyBooking == null)
                return BadRequest(new { message = "Cập nhật lịch đặt tháng thất bại." });

            try
            {
                string childBookingFilter = $"?$filter=MonthlyBookingId eq {id}";
                var childBookings = await _bookingService.GetBookingAsync(accessToken, childBookingFilter);
                if (childBookings != null && childBookings.Any())
                {
                    foreach (var childBooking in childBookings)
                    {
                        var childUpdateDto = new BookingUpdateDto { Status = dto.Status, UserId = childBooking.UserId, Date = childBooking.Date, TotalPrice = childBooking.TotalPrice, OriginalPrice = childBooking.OriginalPrice, Note = childBooking.Note, DiscountId = childBooking.DiscountId, StadiumId = childBooking.StadiumId, };
                        await _bookingService.UpdateBookingAsync(childBooking.Id, childUpdateDto, accessToken);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật các lịch đặt con cho MonthlyBookingId {id}: {ex.Message}");
                return BadRequest(new { message = $"Cập nhật lịch cha thành công, nhưng thất bại khi đồng bộ các lịch con: {ex.Message}" });
            }

            return Json(new { success = true, booking = updatedMonthlyBooking });
        }
    }
}