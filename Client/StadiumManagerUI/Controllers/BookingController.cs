using System.Configuration;
using System.Text.Json;
using DTOs.BookingDTO;
using DTOs.BookingDTO.ViewModel;
using DTOs.Helpers;
using DTOs.NotificationDTO;
using DTOs.StadiumDTO;
using DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Services;
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
        private readonly INotificationService _notificationService;
        private readonly IConfiguration _configuration;



        public BookingController(
            ITokenService tokenService,
            IBookingService bookingService,
            IStadiumService stadiumService,
            IDiscountService discountService,
            IUserService userService,
            INotificationService notificationService,
            IConfiguration configuration)
        {
            _tokenService = tokenService;
            _bookingService = bookingService;
            _stadiumService = stadiumService;
            _discountService = discountService;
            _userService = userService;
            _notificationService = notificationService;
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
                    // ✅ Gửi thông báo cho người được tạo booking nếu không phải khách vãng lai
                    if (customerUserId != 0)
                    {
                        await SendNotificationToCreatedUserAsync(createdBooking, customerUserId, bookingToCreate.StadiumId);
                    }

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

        private async Task SendNotificationToCreatedUserAsync(BookingReadDto booking, int userId, int stadiumId)
        {
            try
            {
                var stadium = await _stadiumService.GetStadiumByIdAsync(stadiumId);

                if (stadium != null)
                {
                    string notifType = "Booking.New";
                    string notifTitle = "Bạn có một lịch đặt sân mới";
                    string notifMessage = $"Chủ sân '{stadium.Name}' đã tạo giúp bạn một lịch đặt sân mới vào ngày {booking.Date}";
                    var notifParams = new { booking.Id, stadiumId };

                    var notificationDto = new CreateNotificationDto
                    {
                        UserId = userId,
                        Type = notifType,
                        Title = notifTitle,
                        Message = notifMessage,
                        Parameters = JsonSerializer.Serialize(notifParams),
                    };

                    await _notificationService.SendNotificationToUserAsync(notificationDto);
                    Console.WriteLine($"[Notification] Đã gửi thông báo cho userId {userId} về booking {booking.Id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[NotificationError] Lỗi khi gửi thông báo cho userId {userId} booking {booking.Id}: {ex.Message}");
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
        public async Task<IActionResult> BookingManager(int dailyPage = 1, int monthlyPage = 1, int? filterMonth = null, int? filterYear = null, int? stadiumId = null, string status = null)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
                return RedirectToAction("Login", "Account");

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            // Lưu lại các giá trị filter để hiển thị trên view
            ViewBag.CurrentFilterMonth = filterMonth ?? DateTime.UtcNow.Month;
            ViewBag.CurrentFilterYear = filterYear ?? DateTime.UtcNow.Year;
            ViewBag.CurrentStadiumId = stadiumId;
            ViewBag.CurrentStatus = status;

            var viewModel = new BookingManagementViewModel();
            const int pageSize = 10;
            ViewBag.DailyCurrentPage = dailyPage;
            ViewBag.MonthlyCurrentPage = monthlyPage;
            ViewBag.PageSize = pageSize;

            // Lấy sân của chủ sân
            string stadiumQuery = $"&$filter=CreatedBy eq {userId}";
            var stadiumsJson = await _stadiumService.SearchStadiumAsync(stadiumQuery);
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
                catch (JsonException) { /* ... error handling ... */ }
            }
            ViewBag.Stadiums = stadiums;

            if (stadiums.Any())
            {
                var stadiumIds = stadiums.Select(s => s.Id).ToList();

                // --- CẢI TIẾN: SỬ DỤNG TOÁN TỬ "in" CỦA ODATA ---
                string stadiumIdList = string.Join(",", stadiumIds);
                string bookingFilter = $"StadiumId in ({stadiumIdList})";

                // Lấy tất cả dữ liệu lịch đặt
                var allBookings = (await _bookingService.GetBookingAsync(accessToken, $"?$filter={bookingFilter}&$expand=BookingDetails")).Data;
                var allMonthlyBookings = (await _bookingService.GetMonthlyBookingAsync(accessToken, $"?$filter={bookingFilter}")).Data;

                // --- TÍNH TOÁN THỐNG KÊ ---
                var now = DateTime.UtcNow;
                var statsBookings = allBookings.Where(b => b.Date.Year == now.Year && b.Date.Month == now.Month);
                ViewBag.CancelledBookingsThisMonth = statsBookings.Count(b => b.Status.Equals("cancelled", StringComparison.OrdinalIgnoreCase) || b.Status.Equals("payfail", StringComparison.OrdinalIgnoreCase));
                ViewBag.AcceptedBookingsThisMonth = statsBookings.Count(b => b.Status.Equals("accepted", StringComparison.OrdinalIgnoreCase) || b.Status.Equals("completed", StringComparison.OrdinalIgnoreCase));
                ViewBag.TotalRevenueThisMonth = statsBookings.Where(b => b.Status.Equals("accepted", StringComparison.OrdinalIgnoreCase) || b.Status.Equals("completed", StringComparison.OrdinalIgnoreCase)).Sum(b => b.TotalPrice ?? 0);

                // --- ÁP DỤNG BỘ LỌC TỪ FORM ---
                var dailyBookingsQuery = allBookings.Where(b => b.MonthlyBookingId == null);
                var monthlyBookingsQuery = allMonthlyBookings.AsEnumerable();

                if (filterMonth.HasValue && filterMonth > 0)
                {
                    dailyBookingsQuery = dailyBookingsQuery.Where(b => b.Date.Month == filterMonth.Value);
                    monthlyBookingsQuery = monthlyBookingsQuery.Where(mb => mb.Month == filterMonth.Value);
                }
                if (filterYear.HasValue && filterYear > 0)
                {
                    dailyBookingsQuery = dailyBookingsQuery.Where(b => b.Date.Year == filterYear.Value);
                    monthlyBookingsQuery = monthlyBookingsQuery.Where(mb => mb.Year == filterYear.Value);
                }
                if (stadiumId.HasValue)
                {
                    dailyBookingsQuery = dailyBookingsQuery.Where(b => b.StadiumId == stadiumId.Value);
                    monthlyBookingsQuery = monthlyBookingsQuery.Where(mb => mb.StadiumId == stadiumId.Value);
                }
                if (!string.IsNullOrEmpty(status) && !status.Equals("all"))
                {
                    if (status.Equals("cancelled-group"))
                    {
                        var cancelledStatuses = new[] { "cancelled", "payfail" };
                        dailyBookingsQuery = dailyBookingsQuery.Where(b => cancelledStatuses.Contains(b.Status.ToLower()));
                        monthlyBookingsQuery = monthlyBookingsQuery.Where(mb => cancelledStatuses.Contains(mb.Status.ToLower()));
                    }
                    else
                    {
                        dailyBookingsQuery = dailyBookingsQuery.Where(b => b.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
                        monthlyBookingsQuery = monthlyBookingsQuery.Where(mb => mb.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
                    }
                }

                // --- LẤY THÔNG TIN USER VÀ PHÂN TRANG ---
                var userIdsToFetch = dailyBookingsQuery.Select(b => b.UserId).Concat(monthlyBookingsQuery.Select(b => b.UserId)).Where(id => id != 0).Distinct().ToList();
                var users = userIdsToFetch.Any() ? await _userService.GetUsersByIdsAsync(userIdsToFetch, accessToken) ?? new List<PublicUserProfileDTO>() : new List<PublicUserProfileDTO>();
                var userDictionary = users.ToDictionary(u => u.UserId);
                var defaultUser = new PublicUserProfileDTO { FullName = "Khách vãng lai" };

                var sortedDailyBookings = dailyBookingsQuery.OrderByDescending(b => b.CreatedAt).ToList();
                var sortedMonthlyBookings = monthlyBookingsQuery.OrderByDescending(b => b.CreatedAt).ToList();

                var bookingsInMonthlyPlan = allBookings.Where(b => b.MonthlyBookingId != null).GroupBy(b => b.MonthlyBookingId).ToDictionary(g => g.Key, g => g.ToList());

                ViewBag.DailyTotalPages = (int)Math.Ceiling(sortedDailyBookings.Count / (double)pageSize);
                viewModel.DailyBookings = sortedDailyBookings.Skip((dailyPage - 1) * pageSize).Take(pageSize).Select(b => new DailyBookingWithUserViewModel { Booking = b, User = userDictionary.GetValueOrDefault(b.UserId, defaultUser) }).ToList();

                ViewBag.MonthlyTotalPages = (int)Math.Ceiling(sortedMonthlyBookings.Count / (double)pageSize);
                viewModel.MonthlyBookings = sortedMonthlyBookings.Skip((monthlyPage - 1) * pageSize).Take(pageSize).Select(mb => new MonthlyBookingWithDetailsViewModel { MonthlyBooking = mb, User = userDictionary.GetValueOrDefault(mb.UserId, defaultUser), Bookings = bookingsInMonthlyPlan.GetValueOrDefault(mb.Id, new List<BookingReadDto>()) }).ToList();
            }
            else
            {
                ViewBag.DailyTotalPages = 0;
                ViewBag.MonthlyTotalPages = 0;
            }

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                // Khi ghép file, chúng ta sẽ cần phải tìm cách render đúng phần HTML
                // Tạm thời vẫn trả về một PartialView để giữ code sạch sẽ
                return PartialView("_BookingTablesPartial", viewModel);
            }

            return View(viewModel);
        }
        // Trong file: StadiumManagerUI/Controllers/BookingController.cs

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingUpdateDto dto)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized(new { message = "Token not found" });

            if ("cancelled".Equals(dto.Status, StringComparison.OrdinalIgnoreCase) || "denied".Equals(dto.Status, StringComparison.OrdinalIgnoreCase))
            {
                // --- BẮT ĐẦU SỬA LỖI LOGIC ---
                HttpContext.Session.SetString("AccessToken", accessToken);
                HttpContext.Session.SetInt32("BookingIdToUpdate", id); // Dùng cho cả hai trường hợp
                HttpContext.Session.SetString("FinalStatus", dto.Status);
                HttpContext.Session.SetString("BookingType", "Daily"); // Quan trọng: Đánh dấu đây là booking ngày

                var cancellationFee = (long)(dto.TotalPrice.GetValueOrDefault());

                // Hủy không mất phí: Chuyển đến PaymentController để xử lý tập trung
                if (cancellationFee <= 0)
                {
                    // Chuyển các giá trị từ Session sang TempData để Redirect hoạt động
                    TempData["AccessToken"] = HttpContext.Session.GetString("AccessToken");
                    TempData["BookingIdToUpdate"] = HttpContext.Session.GetInt32("BookingIdToUpdate");
                    TempData["FinalStatus"] = HttpContext.Session.GetString("FinalStatus");
                    TempData["BookingType"] = HttpContext.Session.GetString("BookingType");
                    return Json(new { paymentRequired = false, redirectUrl = Url.Action("HandleFreeCancellation", "Payment") });
                }

                // Hủy có tính phí: Chuyển qua VNPAY
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
                vnpay.AddRequestData("vnp_ReturnUrl", _configuration["VNPAY:ReturnUrl"]); // Dùng chung một ReturnUrl
                vnpay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString());

                string paymentUrl = vnpay.CreateRequestUrl(_configuration["VNPAY:Url"], _configuration["VNPAY:HashSecret"]);
                return Json(new { paymentRequired = true, paymentUrl = paymentUrl });
                // --- KẾT THÚC SỬA LỖI LOGIC ---
            }

            // Cập nhật các trạng thái khác (không phải hủy)
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
            var bookingsToCancelResponse = await _bookingService.GetBookingAsync(accessToken, $"?$filter=MonthlyBookingId eq {id} and ({filter})");
            var bookingsToCancel = bookingsToCancelResponse.Data;
            if (bookingsToCancel == null || !bookingsToCancel.Any())
                return Json(new { success = false, message = "Không tìm thấy lịch đặt hợp lệ để hủy." });

            // --- SỬA LỖI LOGIC ---
            HttpContext.Session.SetString("AccessToken", accessToken);
            HttpContext.Session.SetInt32("MonthlyBookingIdToUpdate", id);
            HttpContext.Session.SetString("ChildBookingIdsToCancel", JsonSerializer.Serialize(bookingsToCancel.Select(b => b.Id)));
            HttpContext.Session.SetString("BookingType", "Monthly"); // Quan trọng: Đánh dấu đây là booking tháng

            var totalCancellationValue = bookingsToCancel.Sum(b => b.TotalPrice.GetValueOrDefault());
            var cancellationFee = (long)(totalCancellationValue);

            if (cancellationFee <= 0)
            {
                TempData["AccessToken"] = HttpContext.Session.GetString("AccessToken");
                TempData["MonthlyBookingIdToUpdate"] = HttpContext.Session.GetInt32("MonthlyBookingIdToUpdate");
                TempData["ChildBookingIdsToCancel"] = HttpContext.Session.GetString("ChildBookingIdsToCancel");
                TempData["BookingType"] = HttpContext.Session.GetString("BookingType");
                return Json(new { paymentRequired = false, redirectUrl = Url.Action("HandleFreeCancellation", "Payment") });
            }

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
            vnpay.AddRequestData("vnp_ReturnUrl", _configuration["VNPAY:ReturnUrl"]); // Dùng chung một ReturnUrl
            vnpay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString());

            string paymentUrl = vnpay.CreateRequestUrl(_configuration["VNPAY:Url"], _configuration["VNPAY:HashSecret"]);
            return Json(new { paymentRequired = true, paymentUrl });
        }
    }
}