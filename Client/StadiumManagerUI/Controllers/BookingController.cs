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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBookingByOwner(BookingCreateByOwnerDto model)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return RedirectToAction("Login", "Account");
            }

            var ownerId = HttpContext.Session.GetInt32("UserId");
            if (ownerId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Dữ liệu không hợp lệ, vui lòng thử lại.";
                return RedirectToAction("CreateBooking");
            }

            // *** SỬA LỖI KHÁCH VÃNG LAI ***
            // Nếu UserId từ form là 0 (khách vãng lai), chuyển nó thành null.
            // API và cơ sở dữ liệu thường xử lý khóa ngoại nullable tốt hơn là giá trị 0.
            int customerUserId = (model.UserId == 0) ? 0 : model.UserId;

            var bookingToCreate = new BookingCreateDto
            {
                StadiumId = model.StadiumId,
                UserId = customerUserId, 
                Date = model.Date,
                TotalPrice = model.TotalPrice,
                OriginalPrice = model.OriginalPrice,
                Status = model.Status,
                PaymentMethod = "Tại quầy",
                CreatedById = ownerId.Value,
                Note = model.Note,
                BookingDetails = model.BookingDetails
            };

            try
            {
                var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                string bookingJson = JsonSerializer.Serialize(bookingToCreate, jsonOptions);
                Console.WriteLine("--- DEBUG: Dữ liệu gửi đi để tạo Booking ---");
                Console.WriteLine(bookingJson);
                Console.WriteLine("------------------------------------------");

                var createdBooking = await _bookingService.CreateBookingByOwnerAsync(bookingToCreate, accessToken);

                if (createdBooking != null)
                {
                    TempData["SuccessMessage"] = "Tạo lịch đặt sân thành công!";
                    return RedirectToAction("CreateBooking");
                }
                else
                {
                    TempData["ErrorMessage"] = "Tạo lịch đặt không thành công. Vui lòng kiểm tra lại.";
                    return RedirectToAction("CreateBooking");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating booking by owner: {ex.Message}");
                TempData["ErrorMessage"] = "Đã có lỗi xảy ra trong quá trình tạo lịch đặt.";
                return RedirectToAction("CreateBooking");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBookedCourtsByDay(int stadiumId, DateTime date)
        {
            // Endpoint này không cần token vì nó chỉ hiển thị thông tin công khai (slot đã bị khóa).
            // Tuy nhiên, nếu bạn muốn bảo mật, có thể thêm kiểm tra token ở đây.
            try
            {
                var result = await _bookingService.GetBookedCourtsAsync(stadiumId, date);
                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetBookedCourtsByDay: {ex.Message}");
                return StatusCode(500, "Lỗi server khi lấy dữ liệu các sân đã đặt.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchUsers(string query)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { message = "Token not found" });
            }

            if (string.IsNullOrWhiteSpace(query))
            {
                return Json(new List<PublicUserProfileDTO>());
            }

            try
            {
                List<PublicUserProfileDTO> users;
                if (query.Contains("@"))
                {
                    users = await _userService.SearchUsersByEmailAsync(query, accessToken);
                }
                else
                {
                    users = await _userService.SearchUsersByPhoneAsync(query, accessToken);
                }
                return Json(users ?? new List<PublicUserProfileDTO>());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching users: {ex.Message}");
                return StatusCode(500, "An error occurred while searching for users.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateBooking()
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
                return RedirectToAction("Login", "Account");

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

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
                    Console.WriteLine($"Error parsing stadiums JSON for CreateBooking: {ex.Message}");
                }
            }

            ViewBag.OwnedStadiums = stadiums;
            return View();
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
                var courtNameLookup = stadiums
                    .SelectMany(s => s.Courts)
                    .ToDictionary(c => c.Id, c => c.Name);

                var stadiumIds = stadiums.Select(s => s.Id);
                string bookingFilter = string.Join(" or ", stadiumIds.Select(id => $"StadiumId eq {id}"));

                var allBookings = await _bookingService.GetBookingAsync(accessToken, $"?$filter=({bookingFilter})&$expand=BookingDetails") ?? new List<BookingReadDto>();
                var monthlyBookings = await _bookingService.GetMonthlyBookingAsync(accessToken, $"?$filter={bookingFilter}") ?? new List<MonthlyBookingReadDto>();

                foreach (var booking in allBookings)
                {
                    foreach (var detail in booking.BookingDetails)
                    {
                        if (courtNameLookup.TryGetValue(detail.CourtId, out var courtName))
                        {
                            detail.CourtName = courtName;
                        }
                        else
                        {
                            detail.CourtName = $"Sân {detail.CourtId}";
                        }
                    }
                }

                var dailyUserIds = allBookings.Where(b => b.MonthlyBookingId == null).Select(b => b.UserId);
                var monthlyUserIds = monthlyBookings.Select(b => b.UserId);
                var allUserIds = dailyUserIds.Concat(monthlyUserIds).Where(id => id != 0).Distinct().ToList();

                var users = new List<PublicUserProfileDTO>();
                if (allUserIds.Any())
                {
                    users = await _userService.GetUsersByIdsAsync(allUserIds, accessToken) ?? new List<PublicUserProfileDTO>();
                }
                var userDictionary = users.ToDictionary(u => u.UserId);
                var defaultUser = new PublicUserProfileDTO { FullName = "Khách vãng lai" };

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
                    HttpContext.Session.SetString("AccessToken", accessToken);

                    var vnpay = new VnPayLibrary();
                    vnpay.AddRequestData("vnp_Version", _configuration["VNPAY:Version"]);
                    vnpay.AddRequestData("vnp_Command", _configuration["VNPAY:Command"]);
                    vnpay.AddRequestData("vnp_TmnCode", _configuration["VNPAY:TmnCode"]);
                    vnpay.AddRequestData("vnp_Amount", (cancellationFee * 100).ToString());
                    vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
                    vnpay.AddRequestData("vnp_CurrCode", _configuration["VNPAY:CurrCode"]);
                    vnpay.AddRequestData("vnp_IpAddr", "127.0.0.1");
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

            if (!"cancelled".Equals(dto.Status, StringComparison.OrdinalIgnoreCase) || dto.ChildBookingIdsToCancel == null || !dto.ChildBookingIdsToCancel.Any())
            {
                return BadRequest(new { message = "Yêu cầu không hợp lệ cho quy trình hủy." });
            }

            var filter = string.Join(" or ", dto.ChildBookingIdsToCancel.Select(childId => $"Id eq {childId}"));
            var bookingsToCancel = await _bookingService.GetBookingAsync(accessToken, $"?$filter=MonthlyBookingId eq {id} and ({filter})");

            if (bookingsToCancel == null || !bookingsToCancel.Any())
                return Json(new { success = false, message = "Không tìm thấy lịch đặt hợp lệ để hủy." });

            var totalCancellationValue = bookingsToCancel.Sum(b => b.TotalPrice.GetValueOrDefault());
            var cancellationFee = (long)(totalCancellationValue);

            if (cancellationFee <= 0)
            {
                TempData["AccessToken"] = accessToken;
                TempData["MonthlyBookingId"] = id;
                TempData["ChildIdsToCancel"] = JsonSerializer.Serialize(bookingsToCancel.Select(b => b.Id));
                return RedirectToAction("HandleFreeCancellation", "Payment");
            }

            HttpContext.Session.SetString("AccessToken", accessToken);
            HttpContext.Session.SetInt32("MonthlyBookingIdToUpdate", id);
            HttpContext.Session.SetString("ChildBookingIdsToCancel", JsonSerializer.Serialize(bookingsToCancel.Select(b => b.Id)));

            var vnpay = new VnPayLibrary();
            vnpay.AddRequestData("vnp_Version", _configuration["VNPAY:Version"]);
            vnpay.AddRequestData("vnp_Command", _configuration["VNPAY:Command"]);
            vnpay.AddRequestData("vnp_TmnCode", _configuration["VNPAY:TmnCode"]);
            vnpay.AddRequestData("vnp_Amount", (cancellationFee * 100).ToString());
            vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", _configuration["VNPAY:CurrCode"]);
            vnpay.AddRequestData("vnp_IpAddr", HttpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1");
            vnpay.AddRequestData("vnp_Locale", _configuration["VNPAY:Locale"]);
            vnpay.AddRequestData("vnp_OrderInfo", $"Thanh toan phi huy cho lich dat thang #{id}");
            vnpay.AddRequestData("vnp_OrderType", "other");
            vnpay.AddRequestData("vnp_ReturnUrl", _configuration["VNPAY:ReturnUrl"]);
            vnpay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString());

            string paymentUrl = vnpay.CreateRequestUrl(_configuration["VNPAY:Url"], _configuration["VNPAY:HashSecret"]);

            return Json(new { paymentRequired = true, paymentUrl });
        }
    }
}