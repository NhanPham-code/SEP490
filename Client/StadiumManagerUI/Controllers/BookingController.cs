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
using StadiumAPI.DTOs;
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
        private readonly ICourtRelationService _courtRelationService;
        private readonly ICourtService _courtService;
        private readonly IConfiguration _configuration;



        public BookingController(
            ITokenService tokenService,
            IBookingService bookingService,
            IStadiumService stadiumService,
            IDiscountService discountService,
            IUserService userService,
            INotificationService notificationService,
            ICourtRelationService courtRelationService,
            ICourtService courtService,
            IConfiguration configuration)
        {
            _tokenService = tokenService;
            _bookingService = bookingService;
            _stadiumService = stadiumService;
            _discountService = discountService;
            _userService = userService;
            _notificationService = notificationService;
            _courtService = courtService;
            _courtRelationService   = courtRelationService;
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
            ViewBag.CurrentFilterMonth = filterMonth ?? 0;
            ViewBag.CurrentFilterYear = filterYear ?? 0;
            ViewBag.CurrentStadiumId = stadiumId;
            ViewBag.CurrentStatus = status ?? "all";

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

                var courtTasks = stadiumIds.Select(id => _courtService.GetAllCourtsAsync(id));
                var courtResults = await Task.WhenAll(courtTasks);

                var courtMap = courtResults.SelectMany(c => c)
                                   .ToDictionary(c => c.Id, c => c.Name);

                string stadiumIdList = string.Join(",", stadiumIds);
                string bookingFilter = $"StadiumId in ({stadiumIdList})";

                var allBookings = (await _bookingService.GetBookingAsync(accessToken, $"?$filter={bookingFilter}&$expand=BookingDetails")).Data;
                var allMonthlyBookings = (await _bookingService.GetMonthlyBookingAsync(accessToken, $"?$filter={bookingFilter}")).Data;

                foreach (var booking in allBookings)
                {
                    if (booking.BookingDetails != null)
                    {
                        foreach (var detail in booking.BookingDetails)
                        {
                            // Giả sử detail có thuộc tính CourtName (nếu DTO chưa có thì bạn phải thêm vào DTO)
                            if (courtMap.TryGetValue(detail.CourtId, out string name))
                            {
                                detail.CourtName = name;
                            }
                            else
                            {
                                detail.CourtName = $"Sân {detail.CourtId}"; // Fallback nếu không tìm thấy
                            }
                        }
                    }
                }

                    var now = DateTime.UtcNow;
                var statsBookings = allBookings.Where(b => b.Date.Year == now.Year && b.Date.Month == now.Month);
                ViewBag.CancelledBookingsThisMonth = statsBookings.Count(b => b.Status.Equals("cancelled", StringComparison.OrdinalIgnoreCase) || b.Status.Equals("payfail", StringComparison.OrdinalIgnoreCase));
                ViewBag.AcceptedBookingsThisMonth = statsBookings.Count(b => b.Status.Equals("accepted", StringComparison.OrdinalIgnoreCase) || b.Status.Equals("completed", StringComparison.OrdinalIgnoreCase));
                ViewBag.TotalRevenueThisMonth = statsBookings.Where(b => b.Status.Equals("accepted", StringComparison.OrdinalIgnoreCase) || b.Status.Equals("completed", StringComparison.OrdinalIgnoreCase)).Sum(b => b.TotalPrice ?? 0);

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
                        var cancelledStatuses = new[] { "cancelled", "denied", "payfail" };
                        dailyBookingsQuery = dailyBookingsQuery.Where(b => cancelledStatuses.Contains(b.Status.ToLower()));
                        monthlyBookingsQuery = monthlyBookingsQuery.Where(mb => cancelledStatuses.Contains(mb.Status.ToLower()));
                    }
                    else
                    {
                        dailyBookingsQuery = dailyBookingsQuery.Where(b => b.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
                        monthlyBookingsQuery = monthlyBookingsQuery.Where(mb => mb.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
                    }
                }

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
                return PartialView("_BookingTablesPartial", viewModel);
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourtRelationBychildId(int childId)
        {
            try
            {
                if (childId <= 0)
                {
                    return BadRequest("Invalid childId parameter");
                }

                var courtRelations = await _courtRelationService.GetAllCourtRelationBychildId(childId);

                if (courtRelations == null || !courtRelations.Any())
                {
                    return Json(new List<ReadCourtRelationDTO>());
                }

                return Json(courtRelations);
            }
            catch (Exception ex)
            {
                // Log the exception if you have logging configured
                // _logger.LogError(ex, "Error occurred while getting court relations for childId: {ChildId}", childId);

                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourtRelationByParentId(int parentId)
        {
            try
            {
                if (parentId <= 0)
                {
                    return BadRequest("Invalid parentId parameter");
                }

                var courtRelations = await _courtRelationService.GetAllCourtRelationByParentId(parentId);

                if (courtRelations == null || !courtRelations.Any())
                {
                    return Json(new List<ReadCourtRelationDTO>());
                }

                return Json(courtRelations);
            }
            catch (Exception ex)
            {
                // Log the exception if you have logging configured
                // _logger.LogError(ex, "Error occurred while getting court relations for parentId: {ParentId}", parentId);

                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        // Trong file: StadiumManagerUI/Controllers/BookingController.cs

        private async Task<bool> CancelDailyBookingDirectly(int bookingId, string accessToken)
        {
            try
            {
                var booking = (await _bookingService.GetBookingAsync(accessToken, $"?$filter=Id eq {bookingId}")).Data.FirstOrDefault();
                if (booking == null)
                {
                    Console.WriteLine($"[CancelDailyBookingDirectly] Booking với ID {bookingId} không tồn tại.");
                    return false;
                }

                var updateDto = new BookingUpdateDto
                {
                    Status = "cancelled",
                    UserId = booking.UserId,
                    CreatedById = booking.CreatedById,
                    StadiumId = booking.StadiumId,
                    Date = booking.Date,
                    TotalPrice = booking.TotalPrice,
                    OriginalPrice = booking.OriginalPrice,
                    Note = booking.Note,
                    DiscountId = booking.DiscountId
                };

                var result = await _bookingService.UpdateBookingAsync(bookingId, updateDto, accessToken);
                if (result == null)
                {
                    Console.WriteLine($"[CancelDailyBookingDirectly] Cập nhật booking {bookingId} thất bại.");
                    return false;
                }

                // Gửi thông báo cho khách hàng (nếu có userId)
                if (booking.UserId != 0)
                {
                    var stadium = await _stadiumService.GetStadiumByIdAsync(booking.StadiumId);
                    var stadiumName = stadium?.Name ?? "sân";
                    var notificationDto = new CreateNotificationDto
                    {
                        UserId = booking.UserId,
                        Type = "Booking.Cancel",
                        Title = "Lịch đặt sân đã bị hủy",
                        Message = $"Lịch đặt của bạn tại sân '{stadiumName}' vào ngày {booking.Date:dd/MM/yyyy} đã được chủ sân hủy.",
                        Parameters = JsonSerializer.Serialize(new { bookingType = "daily", bookingId }),
                    };
                    await _notificationService.SendNotificationToUserAsync(notificationDto);
                }

                Console.WriteLine($"[CancelDailyBookingDirectly] Hủy booking {bookingId} thành công.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CancelDailyBookingDirectly] Lỗi: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Hủy Monthly Booking (các lịch con) trực tiếp (không qua VNPAY) - dùng cho đơn do chủ sân tạo
        /// </summary>
        private async Task<bool> CancelMonthlyBookingDirectly(int monthlyBookingId, List<int> childBookingIdsToCancel, string accessToken)
        {
            try
            {
                var cancelledChildBookings = new List<BookingReadDto>();

                // Hủy từng booking con
                foreach (var childId in childBookingIdsToCancel)
                {
                    var booking = (await _bookingService.GetBookingAsync(accessToken, $"?$filter=Id eq {childId}")).Data.FirstOrDefault();
                    if (booking == null) continue;

                    cancelledChildBookings.Add(booking);
                    var childUpdateDto = new BookingUpdateDto
                    {
                        Status = "cancelled",
                        UserId = booking.UserId,
                        StadiumId = booking.StadiumId,
                        Date = booking.Date,
                        TotalPrice = booking.TotalPrice,
                        OriginalPrice = booking.OriginalPrice,
                        Note = booking.Note,
                        DiscountId = booking.DiscountId
                    };
                    await _bookingService.UpdateBookingAsync(childId, childUpdateDto, accessToken);
                }

                // Cập nhật Monthly Booking cha
                var monthlyBooking = (await _bookingService.GetMonthlyBookingAsync(accessToken, $"?$filter=Id eq {monthlyBookingId}")).Data.FirstOrDefault();
                if (monthlyBooking == null)
                {
                    Console.WriteLine($"[CancelMonthlyBookingDirectly] Không tìm thấy lịch đặt tháng {monthlyBookingId}.");
                    return false;
                }

                var allChildBookingsAfterUpdate = (await _bookingService.GetBookingAsync(accessToken, $"?$filter=MonthlyBookingId eq {monthlyBookingId}")).Data;
                var newTotalPrice = allChildBookingsAfterUpdate
                    .Where(b => !b.Status.Equals("cancelled", StringComparison.OrdinalIgnoreCase))
                    .Sum(b => b.TotalPrice.GetValueOrDefault());
                var remainingActiveBookings = allChildBookingsAfterUpdate
                    .Any(b => !b.Status.Equals("completed", StringComparison.OrdinalIgnoreCase) &&
                              !b.Status.Equals("cancelled", StringComparison.OrdinalIgnoreCase));
                var newMonthlyStatus = remainingActiveBookings ? "accepted" : "cancelled";

                var updateDto = new MonthlyBookingUpdateDto
                {
                    Status = newMonthlyStatus,
                    TotalPrice = newTotalPrice,
                    PaymentMethod = monthlyBooking.PaymentMethod,
                    OriginalPrice = monthlyBooking.OriginalPrice,
                    Note = monthlyBooking.Note,
                };
                await _bookingService.UpdateMonthlyBookingAsync(monthlyBookingId, updateDto, accessToken);

                // Gửi thông báo
                if (cancelledChildBookings.Any() && monthlyBooking.UserId != 0)
                {
                    var stadium = await _stadiumService.GetStadiumByIdAsync(monthlyBooking.StadiumId);
                    var stadiumName = stadium?.Name ?? "sân";
                    bool isFullCancellation = !remainingActiveBookings;
                    string notifType, notifTitle, notifMessage;

                    if (isFullCancellation)
                    {
                        notifType = "MonthlyBooking.Cancel";
                        notifTitle = "Gói đặt sân đã bị hủy";
                        notifMessage = $"Chủ sân đã hủy toàn bộ gói đặt sân tháng của bạn tại sân '{stadiumName}'. ";
                    }
                    else
                    {
                        notifType = "Booking.Cancel";
                        notifTitle = "Một vài lịch đặt đã bị hủy";
                        var cancelledDates = string.Join(", ", cancelledChildBookings.Select(b => b.Date.ToString("dd/MM")));
                        notifMessage = $"Chủ sân đã hủy các lịch đặt ngày: {cancelledDates} trong gói đặt sân tại '{stadiumName}'.";
                    }

                    var notificationDto = new CreateNotificationDto
                    {
                        UserId = monthlyBooking.UserId,
                        Type = notifType,
                        Title = notifTitle,
                        Message = notifMessage,
                        Parameters = JsonSerializer.Serialize(new { bookingType = "monthly", monthlyBookingId })
                    };
                    await _notificationService.SendNotificationToUserAsync(notificationDto);
                }

                Console.WriteLine($"[CancelMonthlyBookingDirectly] Hủy monthly booking {monthlyBookingId} thành công.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CancelMonthlyBookingDirectly] Lỗi: {ex.Message}");
                return false;
            }
        }

        // =====================================================
        // CÁC ACTION CẬP NHẬT BOOKING
        // =====================================================

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingUpdateDto dto)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized(new { message = "Token not found" });

            if ("cancelled".Equals(dto.Status, StringComparison.OrdinalIgnoreCase))
            {
                // *** KIỂM TRA CREATEDBYID ***
                // Nếu CreatedById != 0 (chủ sân tạo) → Hủy trực tiếp, không cần thanh toán phí
                if (dto.CreatedById != 0)
                {
                    var success = await CancelDailyBookingDirectly(id, accessToken);
                    if (success)
                    {
                        return Json(new { success = true, message = "Hủy lịch đặt thành công (đơn do chủ sân tạo)." });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Hủy lịch đặt thất bại." });
                    }
                }

                // *** KHÁCH TỰ ĐẶT (CreatedById == 0) → Kiểm tra phí hủy qua VNPAY ***
                HttpContext.Session.SetString("AccessToken", accessToken);
                HttpContext.Session.SetInt32("BookingIdToUpdate", id);
                HttpContext.Session.SetString("FinalStatus", dto.Status);
                HttpContext.Session.SetString("BookingType", "Daily");

                var cancellationFee = (long)(dto.TotalPrice.GetValueOrDefault());

                // Hủy không mất phí (giá = 0)
                if (cancellationFee <= 0)
                {
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
                vnpay.AddRequestData("vnp_ReturnUrl", _configuration["VNPAY:ReturnUrl"]);
                vnpay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString());

                string paymentUrl = vnpay.CreateRequestUrl(_configuration["VNPAY:Url"], _configuration["VNPAY:HashSecret"]);
                return Json(new { paymentRequired = true, paymentUrl = paymentUrl });
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
            var bookingsToCancelResponse = await _bookingService.GetBookingAsync(accessToken, $"? $filter=MonthlyBookingId eq {id} and ({filter})");
            var bookingsToCancel = bookingsToCancelResponse.Data;
            if (bookingsToCancel == null || !bookingsToCancel.Any())
                return Json(new { success = false, message = "Không tìm thấy lịch đặt hợp lệ để hủy." });

            // *** KIỂM TRA CREATEDBYID CỦA CÁC BOOKING CON ***
            // Nếu TẤT CẢ các booking con đều do chủ sân tạo (CreatedById != 0) → Hủy trực tiếp
            bool allCreatedByOwner = bookingsToCancel.All(b => b.CreatedById != 0);

            if (allCreatedByOwner)
            {
                var childIds = bookingsToCancel.Select(b => b.Id).ToList();
                var success = await CancelMonthlyBookingDirectly(id, childIds, accessToken);
                if (success)
                {
                    return Json(new { success = true, message = "Hủy các lịch đặt thành công (đơn do chủ sân tạo)." });
                }
                else
                {
                    return Json(new { success = false, message = "Hủy lịch đặt thất bại." });
                }
            }

            // *** CÓ ÍT NHẤT 1 BOOKING DO KHÁCH TỰ ĐẶT → Kiểm tra phí hủy qua VNPAY ***
            HttpContext.Session.SetString("AccessToken", accessToken);
            HttpContext.Session.SetInt32("MonthlyBookingIdToUpdate", id);
            HttpContext.Session.SetString("ChildBookingIdsToCancel", JsonSerializer.Serialize(bookingsToCancel.Select(b => b.Id)));
            HttpContext.Session.SetString("BookingType", "Monthly");

            // Chỉ tính phí hủy cho các booking do KHÁCH tự đặt (CreatedById == 0)
            var customerBookings = bookingsToCancel.Where(b => b.CreatedById == 0);
            var totalCancellationValue = customerBookings.Sum(b => b.TotalPrice.GetValueOrDefault());
            var cancellationFee = (long)(totalCancellationValue);

            if (cancellationFee <= 0)
            {
                TempData["AccessToken"] = HttpContext.Session.GetString("AccessToken");
                TempData["MonthlyBookingIdToUpdate"] = HttpContext.Session.GetInt32("MonthlyBookingIdToUpdate");
                TempData["ChildIdsToCancel"] = HttpContext.Session.GetString("ChildBookingIdsToCancel");
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
            vnpay.AddRequestData("vnp_IpAddr", HttpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0. 0.1");
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