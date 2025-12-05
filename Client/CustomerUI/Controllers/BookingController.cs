using DTOs.BookingDTO;
using DTOs.BookingDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Service.Services;
using StadiumAPI.DTOs;
using System.Text.Json;
using DTOs.Helpers;
using System.Net;
using DTOs.BookingDTO.ViewModel;
using DTOs.StadiumDTO;
using DTOs.UserDTO;
using DTOs.DiscountDTO;
using Newtonsoft.Json;

namespace CustomerUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IDiscountService _discountService;
        private readonly IStadiumService _stadiumService;
        private readonly ICourtRelationService _courtRelationService;
        private readonly IConfiguration _configuration;

        public BookingController(
            IBookingService bookingService,
            ITokenService tokenService,
            IUserService userService,
            IDiscountService discountService,
            IStadiumService stadiumService,
            ICourtRelationService courtRelationService,
            IConfiguration configuration)
        {
            _bookingService = bookingService;
            _tokenService = tokenService;
            _userService = userService;
            _discountService = discountService;
            _stadiumService = stadiumService;
            _courtRelationService = courtRelationService;
            _configuration = configuration;
        }


        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingCreateDto bookingDto)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Thông tin đặt sân không hợp lệ. Vui lòng kiểm tra lại.";
                return RedirectToAction("Checkout"); // Hoặc trang trước đó
            }
            var accessToken = GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
                return RedirectToAction("Login", "Common");

            var allSlotsToCheck = new List<BookingSlotRequest>();
            var allCourtIdsInvolved = new HashSet<int>();

            // 1. Lấy tất cả các sân gốc và các sân liên quan
            foreach (var detail in bookingDto.BookingDetails)
            {
                allCourtIdsInvolved.Add(detail.CourtId); // Thêm sân gốc

                // Tìm các sân liên quan (với vai trò là parent)
                var relatedAsParent = await _courtRelationService.GetAllCourtRelationByParentId(detail.CourtId);
                foreach (var relation in relatedAsParent)
                {
                    allCourtIdsInvolved.Add(relation.ChildCourtId);
                }

                // Tìm các sân liên quan (với vai trò là child)
                var relatedAsChild = await _courtRelationService.GetAllCourtRelationBychildId(detail.CourtId);
                foreach (var relation in relatedAsChild)
                {
                    allCourtIdsInvolved.Add(relation.ParentCourtId);
                }
            }

            // 2. Tạo danh sách kiểm tra cuối cùng: mỗi sân liên quan sẽ được kiểm tra với mỗi khung giờ được yêu cầu
            foreach (var detail in bookingDto.BookingDetails)
            {
                foreach (var courtId in allCourtIdsInvolved)
                {
                    allSlotsToCheck.Add(new BookingSlotRequest
                    {
                        CourtId = courtId,
                        StartTime = detail.StartTime,
                        EndTime = detail.EndTime
                    });
                }
            }

            // Loại bỏ các slot bị trùng lặp để tối ưu hóa việc kiểm tra
            // (Ví dụ: đặt 2 sân A, B cùng giờ, cả 2 đều liên quan đến C -> chỉ cần check C một lần)
            var distinctSlotsToCheck = allSlotsToCheck
                .GroupBy(s => new { s.CourtId, s.StartTime, s.EndTime })
                .Select(g => g.First())
                .ToList();

            // 3. Gọi service để kiểm tra
            bool isAvailable = await _bookingService.CheckSlotsAvailabilityAsync(distinctSlotsToCheck, accessToken);

            // 4. Xử lý kết quả
            if (!isAvailable)
            {
                TempData["ErrorMessage"] = "Rất tiếc, một hoặc nhiều khung giờ bạn chọn (hoặc sân liên quan) đã có người khác đặt. Vui lòng chọn lại.";
                var stadiumId = bookingDto.StadiumId;
                return RedirectToAction("StadiumDetail", "Stadium", new { id = stadiumId });
            }


            // Nếu không có xung đột, tiếp tục quy trình tạo booking
            bookingDto.Status = "waiting";
            var createdBooking = await _bookingService.CreateBookingAsync(bookingDto, accessToken);

            if (createdBooking == null)
            {
                TempData["ErrorMessage"] = "Không thể tạo booking. Vui lòng thử lại.";
                return RedirectToAction("Checkout"); // Hoặc trang trước đó
            }

            // Lưu thông tin bookingId và accessToken để callback sử dụng
            HttpContext.Session.SetInt32("BookingId", createdBooking.Id);
            HttpContext.Session.SetString("AccessToken", accessToken);

            // Tạo URL VNPay
            var vnpay = new VnPayLibrary();
            var tick = DateTime.Now.Ticks.ToString();

            vnpay.AddRequestData("vnp_Version", _configuration["VNPAY:Version"]);
            vnpay.AddRequestData("vnp_Command", _configuration["VNPAY:Command"]);
            vnpay.AddRequestData("vnp_TmnCode", _configuration["VNPAY:TmnCode"]);
            vnpay.AddRequestData("vnp_Amount", ((long)createdBooking.TotalPrice.GetValueOrDefault() * 100).ToString());
            vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", _configuration["VNPAY:CurrCode"]);
            vnpay.AddRequestData("vnp_IpAddr", GetIpAddress());
            vnpay.AddRequestData("vnp_Locale", _configuration["VNPAY:Locale"]);
            vnpay.AddRequestData("vnp_OrderInfo", $"BookingId:{createdBooking.Id}");
            vnpay.AddRequestData("vnp_OrderType", "other");
            vnpay.AddRequestData("vnp_ReturnUrl", _configuration["VNPAY:ReturnUrl"]);
            vnpay.AddRequestData("vnp_TxnRef", tick);
            vnpay.AddRequestData("vnp_ExpireDate", DateTime.Now.AddMinutes(5).ToString("yyyyMMddHHmmss"));

            string paymentUrl = vnpay.CreateRequestUrl(_configuration["VNPAY:Url"], _configuration["VNPAY:HashSecret"]);
            HttpContext.Session.SetInt32("BookingId", createdBooking.Id);
            return Redirect(paymentUrl);
        }
        public async Task<IActionResult> BookingHistory()
        {
            var accessToken = GetAccessToken(); // Giả sử phương thức này tồn tại để lấy token
            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Bạn chưa đăng nhập hoặc phiên đã hết hạn.";
                return RedirectToAction("Login", "Account"); // Chuyển hướng đến trang đăng nhập
            }

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                TempData["ErrorMessage"] = "Không thể xác định người dùng.";
                return RedirectToAction("Login", "Account");
            }

            // TÁI SỬ DỤNG ViewModel từ trang quản lý
            var viewModel = new BookingManagementViewModel();

            // Lấy thông tin người dùng hiện tại một lần
            var currentUser = await _userService.GetUsersByIdsAsync(new List<int> { userId.Value }, accessToken);
            var userProfile = currentUser?.FirstOrDefault() ?? new PublicUserProfileDTO { FullName = "Người dùng" };

            try
            {
                // 1. Lấy tất cả booking (cả lẻ và con của tháng) của user
                string bookingFilter = $"?$filter=UserId eq {userId}&$expand=BookingDetails&$orderby=CreatedAt desc";
                var allUserBookings = (await _bookingService.GetBookingAsync(accessToken, bookingFilter)).Data ?? new List<BookingReadDto>();

                // 2. Lấy tất cả các gói đặt tháng của user
                string monthlyBookingFilter = $"?$filter=UserId eq {userId}&$orderby=CreatedAt desc";
                var monthlyBookings = (await _bookingService.GetMonthlyBookingAsync(accessToken, monthlyBookingFilter)).Data ?? new List<MonthlyBookingReadDto>();

                // **MỚI: Lấy thông tin tất cả các mã giảm giá liên quan**
                var allDiscountIds = allUserBookings.Where(b => b.DiscountId.HasValue).Select(b => b.DiscountId.Value)
                                    .Concat(monthlyBookings.Where(b => b.DiscountId.HasValue).Select(b => b.DiscountId.Value))
                                    .Distinct().ToList();

                var discountLookup = new Dictionary<int, ReadDiscountDTO>();
                if (allDiscountIds.Any())
                {
                    // Giả sử có _discountService được inject
                    var discountTasks = allDiscountIds.Select(id => _discountService.GetDiscountByIdAsync(id));
                    var discounts = await Task.WhenAll(discountTasks);
                    foreach (var discount in discounts.Where(d => d != null))
                    {
                        discountLookup[discount.Id] = discount;
                    }
                }

                // 3. Lấy thông tin các sân vận động liên quan
                var allStadiumIds = allUserBookings.Select(b => b.StadiumId)
                                      .Concat(monthlyBookings.Select(b => b.StadiumId))
                                      .Distinct().ToList();

                var stadiumLookup = new Dictionary<int, ReadStadiumDTO>();
                if (allStadiumIds.Any())
                {
                    var stadiumTasks = allStadiumIds.Select(id => _stadiumService.GetStadiumByIdAsync(id));
                    var stadiums = await Task.WhenAll(stadiumTasks);
                    foreach (var stadium in stadiums.Where(s => s != null))
                    {
                        stadiumLookup[stadium.Id] = stadium;
                    }
                }
                ViewBag.AllStadiums = stadiumLookup.Values.ToList(); // Gửi danh sách sân cho View

                // 4. Hoàn thiện CourtName cho các BookingDetails
                var courtNameLookup = stadiumLookup.Values
                    .SelectMany(s => s.Courts)
                    .ToDictionary(c => c.Id, c => c.Name);

                foreach (var booking in allUserBookings)
                {
                    foreach (var detail in booking.BookingDetails)
                    {
                        detail.CourtName = courtNameLookup.GetValueOrDefault(detail.CourtId, $"Sân {detail.CourtId}");
                    }
                }

                // 5. Phân loại và đưa vào ViewModel
                // Lịch đặt ngày (không thuộc gói tháng)
                var dailyBookingsList = allUserBookings.Where(b => b.MonthlyBookingId == null);
                foreach (var booking in dailyBookingsList)
                {
                    viewModel.DailyBookings.Add(new DailyBookingWithUserViewModel
                    {
                        Booking = booking,
                        User = userProfile, // User ở đây là chính họ
                        Discount = booking.DiscountId.HasValue ? discountLookup.GetValueOrDefault(booking.DiscountId.Value) : null
                    });
                }

                // Lịch đặt tháng và các lịch con của nó
                var bookingsInMonthlyPlan = allUserBookings
                    .Where(b => b.MonthlyBookingId != null)
                    .GroupBy(b => b.MonthlyBookingId.Value) // Chắc chắn có giá trị
                    .ToDictionary(g => g.Key, g => g.ToList());

                foreach (var mb in monthlyBookings)
                {
                    viewModel.MonthlyBookings.Add(new MonthlyBookingWithDetailsViewModel
                    {
                        MonthlyBooking = mb,
                        User = userProfile, // User ở đây là chính họ
                        Bookings = bookingsInMonthlyPlan.GetValueOrDefault(mb.Id, new List<BookingReadDto>()),
                        Discount = mb.DiscountId.HasValue ? discountLookup.GetValueOrDefault(mb.DiscountId.Value) : null
                    });
                }
            }
            catch (Exception ex)
            {
                // Ghi lại log lỗi (quan trọng)
                // logger.LogError(ex, "Error fetching booking history for user {UserId}", userId);
                TempData["ErrorMessage"] = "Đã xảy ra lỗi khi tải lịch sử đặt sân của bạn.";
            }
            finally
            {
                HttpContext.Session.Remove("AccessToken");
            }

            return View(viewModel);
        }

        #region Private Helper Methods
        private string? GetAccessToken()
        {
            // **SỬA ĐỔI Ở ĐÂY**
            // Ưu tiên lấy token từ Session (sau khi callback từ VNPay)
            var sessionToken = HttpContext.Session.GetString("AccessToken");
            if (!string.IsNullOrEmpty(sessionToken))
            {
                return sessionToken;
            }

            // Nếu không có trong Session, lấy từ cookie như bình thường
            return Request.Cookies["AccessToken"];
        }

        private string GetIpAddress()
        {
            // ... giữ nguyên ...
            string ipAddress = string.Empty;
            try
            {
                var remoteIpAddress = HttpContext.Connection.RemoteIpAddress;
                if (remoteIpAddress != null)
                {
                    if (remoteIpAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                    {
                        remoteIpAddress = System.Net.Dns.GetHostEntry(remoteIpAddress).AddressList
                            .FirstOrDefault(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                    }
                    if (remoteIpAddress != null) ipAddress = remoteIpAddress.ToString();
                }
            }
            catch { ipAddress = "127.0.0.1"; }
            return ipAddress;
        }
        #endregion

        public IActionResult BookingSchedule()
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();

            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Bạn chưa đăng nhập hoặc phiên đã hết hạn.";
                return RedirectToAction("Login", "Common");
            }

            // Trả về cùng một View "Booking.cshtml".
            return View();
        }

        public IActionResult Checkout([FromForm] CheckoutRequest request)
        {
            ViewBag.Date = request.Date;
            ViewBag.TotalPrice = request.TotalPrice;
            ViewBag.StadiumId = request.StadiumId;
            ViewBag.Courts = request.Courts;
            ViewBag.AfterPrice = request.AfterPrice;
            ViewBag.DiscountId = request.DiscountId;
            ViewBag.Type = request.Type;
            ViewBag.BookingId = request.BookingId;

            return View();
        }

        [HttpPost]
        public IActionResult CheckoutTimeZone(string date, int startTime, int endTime, decimal totalPrice, string courtId, string stadiumId)
        {
            ViewBag.Date = date;
            ViewBag.StartTime = startTime;
            ViewBag.EndTime = endTime;
            ViewBag.TotalPrice = totalPrice;
            ViewBag.StadiumId = stadiumId;

            // Truyền trực tiếp chuỗi courtId đã được chọn
            // Nó có thể là "1,2,3" hoặc "4"
            ViewBag.CourtIdsString = courtId;

            // Tách ra danh sách để dùng cho logic khác nếu cần
            if (!string.IsNullOrEmpty(courtId))
            {
                ViewBag.CourtIds = courtId.Split(',').Select(c => int.Parse(c.Trim())).ToList();
            }
            else
            {
                ViewBag.CourtIds = new List<int>();
            }

            return View();
        }

        [HttpPost]
        public IActionResult MonthlyCheckout(MonthlyBookingFormViewModel model)
        {
            // Chuyển dữ liệu nhận được từ form sang ViewBag để view MonthlyCheckout.cshtml có thể sử dụng
            ViewBag.Year = model.Year;
            ViewBag.Month = model.Month;
            ViewBag.SelectedDays = model.SelectedDays;
            ViewBag.StartTime = model.StartTime;
            ViewBag.EndTime = model.EndTime;
            ViewBag.SelectedCourtIds = model.SelectedCourtIds;
            ViewBag.TotalPrice = model.TotalPrice;
            ViewBag.StadiumId = model.StadiumId;
            ViewBag.DiscountId = model.DiscountId;
            ViewBag.AfterPrice = model.AfterPrice;
            ViewBag.Type = model.Type;

            // Trả về view cho trang checkout hàng tháng
            return View();
        }

        public async Task<IActionResult> BookingDetail(int id)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                Console.WriteLine($"[BookingDetail] Không tìm thấy booking với ID: {id}");
                TempData["ErrorMessage"] = "Không tìm thấy booking hoặc bạn không có quyền truy cập.";
                return RedirectToAction("BookingHistory");
            }

            try
            {
                var booking = await _bookingService.GetBookingDetailAsync(accessToken, id);
                if (booking == null)
                {
                    TempData["ErrorMessage"] = "Không tìm thấy booking hoặc bạn không có quyền truy cập.";
                    return RedirectToAction("BookingHistory");
                }

                var stadium = await _stadiumService.GetStadiumByIdAsync(booking.StadiumId);
                ViewBag.StadiumName = stadium?.Name ?? "Không xác định";
                ViewBag.PaymentMethod = booking.PaymentMethod;

                decimal originalTotalPrice = booking.TotalPrice.GetValueOrDefault();
                string discountCode = "Không có";
                decimal discountAmount = 0;

                if (booking.DiscountId.HasValue)
                {
                    var discount = await _discountService.GetDiscountByIdAsync(booking.DiscountId.Value);
                    if (discount != null)
                    {
                        discountCode = discount.Code;

                        // Thêm kiểm tra ở đây để tránh chia cho 0
                        if (discount.PercentValue != 100)
                        {
                            // Công thức cho trường hợp giảm theo phần trăm
                            var calculatedDiscount = originalTotalPrice / (1m - ((decimal)discount.PercentValue / 100m)) * ((decimal)discount.PercentValue / 100m);

                            // So sánh với MaxDiscountAmount
                            if (calculatedDiscount > discount.MaxDiscountAmount)
                            {
                                discountAmount = (decimal)discount.MaxDiscountAmount;
                            }
                            else
                            {
                                discountAmount = calculatedDiscount;
                            }
                        }
                        else
                        {
                            // Nếu giảm 100%, số tiền giảm sẽ bằng tổng tiền
                            discountAmount = originalTotalPrice;
                        }

                        // Tính toán tổng tiền ban đầu sau khi đã xác định discountAmount
                        originalTotalPrice = originalTotalPrice + discountAmount;
                    }
                }

                ViewBag.DiscountCode = discountCode;
                ViewBag.DiscountAmount = discountAmount.ToString("N0");
                ViewBag.OriginalTotalPrice = originalTotalPrice.ToString("N0");

                return View(booking);
            }
            catch (Exception ex)
            {
                // Log lỗi để dễ dàng debug
                Console.WriteLine($"[BookingDetail] Lỗi xảy ra: {ex.Message}");
                TempData["ErrorMessage"] = "Lỗi khi lấy chi tiết booking.";
                return RedirectToAction("BookingHistory");
            }
        }

        // Action mới để lấy danh sách giảm giá theo StadiumId
        [HttpGet]
        public async Task<IActionResult> GetDiscounts(int stadiumId)
        {
            var accessToken = GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { message = "Vui lòng đăng nhập để xem mã giảm giá." });
            }

            var currentUserId = HttpContext.Session.GetInt32("UserId");
            if (currentUserId == null)
            {
                return Unauthorized(new { message = "Phiên đăng nhập không hợp lệ." });
            }

            try
            {
                // 1. Lấy tất cả các mã giảm giá cho sân vận động (chưa lọc)
                var allDiscountsForStadium = await _discountService.GetDiscountsByStadiumIdAsync(stadiumId);

                if (allDiscountsForStadium == null || !allDiscountsForStadium.Any())
                {
                    return Ok(new List<ReadDiscountDTO>());
                }
                var now = DateTime.UtcNow;

                var filteredDiscounts = allDiscountsForStadium.Where(discount =>
                {

                    bool isGenerallyValid = discount.IsActive && discount.StartDate <= now && discount.EndDate >= now;

                    if (!isGenerallyValid)
                    {
                        return false;
                    }

                    // Điều kiện 2: Xử lý logic cho mã 'Unique'
                    if (discount.CodeType == "Unique")
                    {

                        if (int.TryParse(discount.TargetUserId, out int targetId))
                        {
                            return targetId == currentUserId.Value; 
                        }
                        return false; 
                    }

                    return true;
                }).ToList();

                return Ok(filteredDiscounts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetDiscounts] Lỗi khi lấy danh sách giảm giá cho sân {stadiumId}: {ex.Message}");
                return StatusCode(500, new { message = "Lỗi server khi lấy danh sách giảm giá." });
            }
        }


        /*public IActionResult Booking()
        {
            return View();
        }*/

        public IActionResult Booking(string stadiumId,
            string? date,
            int? startTime,
            int? endTime,
            string? courtIds)
        {

            var accessToken = _tokenService.GetAccessTokenFromCookie();

            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Bạn chưa đăng nhập hoặc phiên đã hết hạn.";
                return RedirectToAction("Login", "Common");
            }
            // Kiểm tra xem stadiumId có hợp lệ không.
            if (string.IsNullOrEmpty(stadiumId))
            {
                // Nếu không có ID, có thể chuyển hướng về action Booking() ban đầu
                // hoặc trả về một trang lỗi.
                return RedirectToAction("Booking");
            }

            // Truyền stadiumId vào ViewBag để View có thể sử dụng.
            ViewBag.StadiumId = stadiumId;
            ViewBag.RestoreDate = date;
            ViewBag.RestoreStartTime = startTime;
            ViewBag.RestoreEndTime = endTime;
            ViewBag.RestoreCourtIds = courtIds;

            // Trả về cùng một View "Booking.cshtml".
            return View();
        }

        public IActionResult MonthlyBooking(string stadiumId,
            int? year,
            int? month,
            string? selectedDays,
            string? selectedCourtIds,
            int? startTime,
            int? endTime)
        {

            var accessToken = _tokenService.GetAccessTokenFromCookie();

            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Bạn chưa đăng nhập hoặc phiên đã hết hạn.";
                return RedirectToAction("Login", "Common");
            }
            // Kiểm tra xem stadiumId có hợp lệ không.
            if (string.IsNullOrEmpty(stadiumId))
            {
                // Nếu không có ID, có thể chuyển hướng về action Booking() ban đầu
                // hoặc trả về một trang lỗi.
                return RedirectToAction("MonthlyBooking");
            }

            // Truyền stadiumId vào ViewBag để View có thể sử dụng.
            ViewBag.StadiumId = stadiumId;
            ViewBag.RestoreYear = year;
            ViewBag.RestoreMonth = month; 
            ViewBag.RestoreSelectedDays = selectedDays;
            ViewBag.RestoreSelectedCourtIds = selectedCourtIds;
            ViewBag.RestoreStartTime = startTime;
            ViewBag.RestoreEndTime = endTime;

            // Trả về cùng một View "Booking.cshtml".
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetBookedCourts(int stadiumId, DateTime date, int startHour, int endHour)
        {
            // var accessToken = _tokenService.GetAccessTokenFromCookie();
            // if (string.IsNullOrEmpty(accessToken))
            //     return Unauthorized();

            var startTime = date.Date.AddHours(startHour);
            var endTime = date.Date.AddHours(endHour);

            // 1. Gọi service để lấy dữ liệu gốc
            var bookings = await _bookingService.GetBookedCourtsAsync(stadiumId, startTime, endTime);

            // --- LỌC LẠI BOOKING DETAILS TRÊN CLIENT ---
            // Giả định 'bookings' là một List<BookingReadDto>
            if (bookings != null)
            {
                foreach (var booking in bookings)
                {
                    if (booking.BookingDetails == null) continue;

                    // Lọc lại danh sách BookingDetails để chỉ giữ lại những slot
                    // có thời gian nằm trong khoảng yêu cầu.
                    // Logic này kiểm tra sự giao thoa (overlap) thời gian.
                    booking.BookingDetails = booking.BookingDetails
                        .Where(detail =>
                            detail.StartTime < endTime && detail.EndTime > startTime
                        )
                        .ToList();
                }

                // 2. Loại bỏ những booking không còn detail nào sau khi lọc
                var filteredResult = bookings.Where(b => b.BookingDetails != null && b.BookingDetails.Any()).ToList();

                // 3. Trả về kết quả đã được lọc
                return Json(filteredResult);
            }

            // Nếu kết quả từ service là null, trả về JSON rỗng
            return Json(new List<BookingReadDto>());
        }

        [HttpGet]
        public async Task<IActionResult> GetBookedCourtsByDay(int stadiumId, DateTime date)
        {
            //var accessToken = _tokenService.GetAccessTokenFromCookie();
            //if (string.IsNullOrEmpty(accessToken))
            //    return Unauthorized();

            //var startTime = date.Date.AddHours(startHour);
            //var endTime = date.Date.AddHours(endHour);

            var result = await _bookingService.GetBookedCourtsAsync(stadiumId, date);
            return Json(result);
        }


        // add endpoint for Clock.cshtml 
        public IActionResult Clock()
        {
            return View();
        }

        public IActionResult VisuallyBooking(string stadiumId, string? date, string? courts)
        {

            var accessToken = _tokenService.GetAccessTokenFromCookie();

            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Bạn chưa đăng nhập hoặc phiên đã hết hạn.";
                return RedirectToAction("Login", "Common");
            }
            if (string.IsNullOrEmpty(stadiumId))
            {
                // Nếu không có ID, có thể chuyển hướng về action Booking() ban đầu
                // hoặc trả về một trang lỗi.
                return RedirectToAction("VisuallyBooking");
            }

            // Truyền stadiumId vào ViewBag để View có thể sử dụng.
            ViewBag.StadiumId = stadiumId;
            
            ViewBag.RestoreDate = date;
            ViewBag.RestoreCourts = courts;

            // Trả về cùng một View "Booking.cshtml".
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {

            // Get access token from session, cookie, or claims
            var accessToken = GetAccessToken();

            if (string.IsNullOrEmpty(accessToken))
            {
                return Json(new
                {
                    success = false,
                    message = "Không tìm thấy token xác thực. Vui lòng đăng nhập lại.",
                    errorCode = "NO_TOKEN"
                });
            }

            // Call UserService to get profile from Ocelot
            var userProfile = await _userService.GetMyProfileAsync(accessToken);

            if (userProfile == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Không thể lấy thông tin người dùng từ server.",
                    errorCode = "NO_DATA"
                });
            }

            // Return success response
            return Json(new
            {
                success = true,
                data = new
                {
                    fullName = userProfile.FullName ?? "",
                    phoneNumber = userProfile.PhoneNumber ?? "",
                    email = userProfile.Email ?? "",
                    userId = userProfile.UserId
                },
                message = "Lấy thông tin thành công"
            });
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

        [HttpGet]
        public async Task<List<BookingReadDto>> FilterByDateAndHour(int year, int month, List<int> days, int startTime,
            int endTime)
        {
            // Convert int thành "HH:mm"
            string startTimeStr = $"{startTime:D2}:00"; // 13 -> "13:00"
            string endTimeStr = $"{endTime:D2}:00"; // 17 -> "17:00"

            var query = new List<string>
            {
                $"year={year}",
                $"month={month}",
                $"startTime={Uri.EscapeDataString(startTimeStr)}",
                $"endTime={Uri.EscapeDataString(endTimeStr)}"
            };

            foreach (var d in days)
                query.Add($"days={d}");

            var queryString = string.Join("&", query);
            var url = $"https://localhost:7136/booking/filterbydateandhour?{queryString}";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();

                var bookings = JsonConvert.DeserializeObject<List<BookingReadDto>>(data);

                // --- LỌC LẠI BOOKING DETAILS TRÊN CLIENT ---
                foreach (var booking in bookings)
                {
                    if (booking.BookingDetails == null) continue;

                    // Lọc danh sách BookingDetails theo các điều kiện ban đầu
                    booking.BookingDetails = booking.BookingDetails
                        .Where(detail =>
                        {
                            // Giả định: BookingDetail có thuộc tính `StartTime` kiểu DateTime.
                            // Nếu tên thuộc tính của bạn khác (ví dụ: StartDateTime), hãy đổi lại ở đây.
                            var detailStartTime = detail.StartTime;

                            // Kiểm tra tất cả điều kiện
                            return detailStartTime.Year == year &&
                                   detailStartTime.Month == month &&
                                   days.Contains(detailStartTime.Day) &&
                                   detailStartTime.Hour >= startTime &&
                                   detailStartTime.Hour < endTime;
                        })
                        .ToList();
                }

                // Loại bỏ những booking không còn detail nào sau khi lọc
                var filteredResult = bookings.Where(b => b.BookingDetails != null && b.BookingDetails.Any()).ToList();

                return filteredResult;
            }
        }

        [HttpGet]
        public async Task<IActionResult> FilterByCourtAndHour([FromQuery] List<int> courtIds, int year, int month, int startTime, int endTime)
        {
            try
            {
                // if (courtIds == null || !courtIds.Any())
                // {
                //     return BadRequest(new { error = "Cần cung cấp ít nhất một Court ID." });
                // }

                var result = await _bookingService.FilterByCourtAndHour(courtIds, year, month, startTime, endTime);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in FilterByCourtAndHour: {ex.Message}");
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMonthlyBooking([FromForm] MonthlyBookingCreateDto bookingDto)
        {
            var accessToken = GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.";
                return RedirectToAction("Login", "Common");
            }

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Dữ liệu không hợp lệ. Vui lòng kiểm tra lại thông tin.";
                return Redirect(Request.Headers["Referer"].ToString() ?? "/");
            }

            var slotsToCheck = new List<BookingSlotRequest>();
            var allCourtIdsInvolved = new HashSet<int>();


            foreach (var courtId in bookingDto.CourtIds)
            {
                allCourtIdsInvolved.Add(courtId);
                var relatedAsParent = await _courtRelationService.GetAllCourtRelationByParentId(courtId);
                foreach (var relation in relatedAsParent) allCourtIdsInvolved.Add(relation.ChildCourtId);

                var relatedAsChild = await _courtRelationService.GetAllCourtRelationBychildId(courtId);
                foreach (var relation in relatedAsChild) allCourtIdsInvolved.Add(relation.ParentCourtId);
            }

            if (!TimeSpan.TryParse(bookingDto.StartTime, out var startTime) || !TimeSpan.TryParse(bookingDto.EndTime, out var endTime))
            {
                TempData["ErrorMessage"] = "Định dạng thời gian không hợp lệ. Vui lòng dùng HH:mm.";
                return Redirect(Request.Headers["Referer"].ToString() ?? "/");
            }


            foreach (var day in bookingDto.Dates)
            {
                var bookingDate = new DateTime(bookingDto.Year, bookingDto.Month, day);
                foreach (var courtId in allCourtIdsInvolved)
                {
                    slotsToCheck.Add(new BookingSlotRequest
                    {
                        CourtId = courtId,
                        StartTime = bookingDate.Add(startTime),
                        EndTime = bookingDate.Add(endTime)
                    });
                }
            }


            if (slotsToCheck.Any())
            {
                bool isAvailable = await _bookingService.CheckSlotsAvailabilityAsync(slotsToCheck, accessToken);
                if (!isAvailable)
                {
                    TempData["ErrorMessage"] = "Rất tiếc, một trong các ngày bạn chọn đã có người khác đặt sân (hoặc sân liên quan). Vui lòng chọn lại.";
                    return Redirect(Request.Headers["Referer"].ToString() ?? "/");
                }
            }
            try
            {
                // Nếu không có xung đột, tiếp tục tạo MonthlyBooking
                var createdMonthlyBooking = await _bookingService.CreateMonthlyBookingAsync(bookingDto, accessToken);

                if (createdMonthlyBooking != null)
                {
                    // Lưu ID của MonthlyBooking để callback sử dụng
                    HttpContext.Session.SetInt32("MonthlyBookingId", createdMonthlyBooking.Id);
                    HttpContext.Session.SetString("AccessToken", accessToken);

                    // Tạo URL VNPay
                    var vnpay = new VnPayLibrary();
                    var tick = DateTime.Now.Ticks.ToString();

                    vnpay.AddRequestData("vnp_Version", _configuration["VNPAY:Version"]);
                    vnpay.AddRequestData("vnp_Command", _configuration["VNPAY:Command"]);
                    vnpay.AddRequestData("vnp_TmnCode", _configuration["VNPAY:TmnCode"]);
                    vnpay.AddRequestData("vnp_Amount", ((long)createdMonthlyBooking.TotalPrice.GetValueOrDefault() * 100).ToString());
                    vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
                    vnpay.AddRequestData("vnp_CurrCode", _configuration["VNPAY:CurrCode"]);
                    vnpay.AddRequestData("vnp_IpAddr", GetIpAddress());
                    vnpay.AddRequestData("vnp_Locale", _configuration["VNPAY:Locale"]);
                    vnpay.AddRequestData("vnp_OrderInfo", $"MonthlyId:{createdMonthlyBooking.Id}");
                    vnpay.AddRequestData("vnp_OrderType", "other");
                    vnpay.AddRequestData("vnp_ReturnUrl", _configuration["VNPAY:ReturnUrlMonthly"]);
                    vnpay.AddRequestData("vnp_TxnRef", tick);
                    vnpay.AddRequestData("vnp_ExpireDate", DateTime.Now.AddMinutes(5).ToString("yyyyMMddHHmmss"));

                    string paymentUrl = vnpay.CreateRequestUrl(_configuration["VNPAY:Url"], _configuration["VNPAY:HashSecret"]);
                    HttpContext.Session.SetInt32("MonthlyBookingId", createdMonthlyBooking.Id);
                    return Redirect(paymentUrl);
                }
                else
                {
                    TempData["ErrorMessage"] = "Tạo booking hàng tháng thất bại. Vui lòng thử lại.";
                    return Redirect(Request.Headers["Referer"].ToString() ?? "/");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Đã xảy ra lỗi: {ex.Message}";
                return Redirect(Request.Headers["Referer"].ToString() ?? "/");
            }
        }

        public async Task<IActionResult> GetBookingsForWeek(DateTime startDate, DateTime endDate)
        {
            var accessToken = GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { message = "Phiên đăng nhập đã hết hạn." });
            }

            try
            {
                // Định dạng ngày theo chuẩn ISO 8601 UTC (yyyy-MM-ddTHH:mm:ssZ) mà API Ocelot cần
                // Đặt endDate đến cuối ngày để bao gồm tất cả booking trong ngày đó
                var startDateIso = startDate.ToString("yyyy-MM-ddT00:00:00Z");
                var endDateIso = endDate.ToString("yyyy-MM-ddT23:59:59Z");
                var userId = HttpContext.Session.GetInt32("UserId");
                // *** THAY ĐỔI QUAN TRỌNG Ở ĐÂY ***
                // Build query string với điều kiện lọc Status
                var queryString = $"?$filter=UserId eq {userId} and Date ge {startDateIso} and Date le {endDateIso} and (Status eq 'accepted' or Status eq 'waiting' or Status eq 'completed')&$expand=BookingDetails&$orderby=Date asc";
                var bookings = (await _bookingService.GetBookingAsync(accessToken, queryString)).Data;

                if (bookings == null)
                {
                    return NotFound(new { message = "Không tìm thấy booking nào." });
                }

                // Trả về dữ liệu dạng JSON
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetBookingsForWeek] Lỗi: {ex.Message}");
                return StatusCode(500, new { message = "Lỗi server khi lấy dữ liệu booking." });
            }
        }
    }
}