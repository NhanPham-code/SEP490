using DTOs.BookingDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using DTOs.Helpers;
using DTOs.StadiumDTO;
using DTOs.UserDTO;
using DTOs.DiscountDTO;
using DTOs.BookingDTO.ViewModel;
using StadiumAPI.DTOs;

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
                return RedirectToAction("Checkout"); 
            }
            var accessToken = GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
                return RedirectToAction("Login", "Common");

            var allSlotsToCheck = new List<BookingSlotRequest>();
            var allCourtIdsInvolved = new HashSet<int>();
            
            foreach (var detail in bookingDto.BookingDetails)
            {
                allCourtIdsInvolved.Add(detail.CourtId); 
                
                var relatedAsParent = await _courtRelationService.GetAllCourtRelationByParentId(detail.CourtId);
                foreach (var relation in relatedAsParent)
                {
                    allCourtIdsInvolved.Add(relation.ChildCourtId);
                }
                
                var relatedAsChild = await _courtRelationService.GetAllCourtRelationBychildId(detail.CourtId);
                foreach (var relation in relatedAsChild)
                {
                    allCourtIdsInvolved.Add(relation.ParentCourtId);
                }
            }
            
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
            
            var distinctSlotsToCheck = allSlotsToCheck
                .GroupBy(s => new { s.CourtId, s.StartTime, s.EndTime })
                .Select(g => g.First())
                .ToList();
            
            bool isAvailable = await _bookingService.CheckSlotsAvailabilityAsync(distinctSlotsToCheck, accessToken);
            
            if (!isAvailable)
            {
                TempData["ErrorMessage"] = "Rất tiếc, một hoặc nhiều khung giờ bạn chọn (hoặc sân liên quan) đã có người khác đặt. Vui lòng chọn lại.";
                var stadiumId = bookingDto.StadiumId;
                return RedirectToAction("StadiumDetail", "Stadium", new { id = stadiumId });
            }
            
            bookingDto.Status = "waiting";
            var createdBooking = await _bookingService.CreateBookingAsync(bookingDto, accessToken);

            if (createdBooking == null)
            {
                TempData["ErrorMessage"] = "Không thể tạo booking. Vui lòng thử lại.";
                return RedirectToAction("Checkout"); 
            }
            
            HttpContext.Session.SetInt32("BookingId", createdBooking.Id);
            HttpContext.Session.SetString("AccessToken", accessToken);
            
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
            var sessionData = new PendingPaymentSessionDto
            {
                BookingId = createdBooking.Id,
                Type = "Single",
                PaymentUrl = paymentUrl,
                ExpireTime = DateTime.Now.AddMinutes(5) // Lưu thời gian hết hạn để check sau này
            };

            // Serialize object thành JSON string
            string jsonSessionData = System.Text.Json.JsonSerializer.Serialize(sessionData);

            // Lưu vào Session với Key duy nhất theo ID booking để tránh bị đè nếu đặt nhiều cái
            // Key ví dụ: "Payment_Single_102"
            HttpContext.Session.SetString($"Payment_Single_{createdBooking.Id}", jsonSessionData);
            HttpContext.Session.SetInt32("BookingId", createdBooking.Id);
            return Redirect(paymentUrl);
        }
        [HttpGet]
        public async Task<IActionResult> BookingHistory()
        {
            return await FilterDailyBookings(page: 1, status: "all", stadiumId: 0, isAjax: false);
        }

        [HttpGet]
        public async Task<IActionResult> FilterDailyBookings(int page = 1, string status = "all", int stadiumId = 0, bool isAjax = true)
        {
            var accessToken = GetAccessToken();
            if (string.IsNullOrEmpty(accessToken)) return isAjax ? Unauthorized() : RedirectToAction("Login", "Account");

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return isAjax ? Unauthorized() : RedirectToAction("Login", "Account");

            var viewModel = new BookingManagementViewModel();
            int pageSize = 10;
            int skip = (page - 1) * pageSize;

            try
            {
                // ==================================================================================
                // 1. XỬ LÝ DAILY BOOKING (CÓ PHÂN TRANG + FILTER)
                // ==================================================================================
                var dailyFilters = new List<string> { $"UserId eq {userId}", "MonthlyBookingId eq null" }; // Chỉ lấy đơn lẻ

                if (!string.IsNullOrEmpty(status) && status != "all")
                {
                    if (status == "cancelled-group") dailyFilters.Add("(Status eq 'cancelled' or Status eq 'payfail' or Status eq 'denied')");
                    else dailyFilters.Add($"Status eq '{status}'");
                }
                if (stadiumId > 0) dailyFilters.Add($"StadiumId eq {stadiumId}");

                string dailyQuery = $"?$filter={string.Join(" and ", dailyFilters)}&$expand=BookingDetails&$orderby=CreatedAt desc&$count=true&$skip={skip}&$top={pageSize}";

                var dailyResult = await _bookingService.GetBookingAsync(accessToken, dailyQuery);
                var dailyBookings = dailyResult.Data ?? new List<BookingReadDto>();
                int dailyTotalCount = dailyResult.TotalCount;

                // ==================================================================================
                // 2. XỬ LÝ MONTHLY BOOKING & CHILDREN (GIỮ NGUYÊN LOGIC CŨ CỦA BẠN)
                // ==================================================================================
                var monthlyBookings = new List<MonthlyBookingReadDto>();
                var bookingChildren = new List<BookingReadDto>();

                // Chỉ load Monthly khi không phải AJAX (hoặc load lại nếu muốn, nhưng thường AJAX chỉ phân trang bảng Daily)
                if (!isAjax)
                {
                    // 2a. Lấy danh sách Monthly Booking
                    string monthlyQuery = $"?$filter=UserId eq {userId}&$orderby=CreatedAt desc";
                    var monthlyResult = await _bookingService.GetMonthlyBookingAsync(accessToken, monthlyQuery);
                    monthlyBookings = monthlyResult.Data ?? new List<MonthlyBookingReadDto>();

                    // 2b. Lấy danh sách Booking Con (Logic cũ của bạn là lấy allUserBookings rồi lọc)
                    // Để tối ưu, ta chỉ lấy những booking CÓ MonthlyBookingId
                    string childrenQuery = $"?$filter=UserId eq {userId} and MonthlyBookingId ne null&$expand=BookingDetails";
                    var childrenResult = await _bookingService.GetBookingAsync(accessToken, childrenQuery);
                    bookingChildren = childrenResult.Data ?? new List<BookingReadDto>();
                }

                // ==================================================================================
                // 3. LOOKUP DATA (STADIUM & DISCOUNT) - GIỮ NGUYÊN
                // ==================================================================================
                var allStadiumIds = dailyBookings.Select(b => b.StadiumId)
                                    .Concat(monthlyBookings.Select(b => b.StadiumId))
                                    .Concat(bookingChildren.Select(b => b.StadiumId))
                                    .Distinct().ToList();

                var stadiumLookup = new Dictionary<int, ReadStadiumDTO>();
                if (allStadiumIds.Any())
                {
                    var tasks = allStadiumIds.Select(id => _stadiumService.GetStadiumByIdAsync(id));
                    var results = await Task.WhenAll(tasks);
                    foreach (var s in results.Where(x => x != null)) stadiumLookup[s.Id] = s;
                }
                ViewBag.AllStadiums = stadiumLookup.Values.ToList();

                var courtNameLookup = stadiumLookup.Values.SelectMany(s => s.Courts).ToDictionary(c => c.Id, c => c.Name);

                // Map tên sân cho Daily
                foreach (var b in dailyBookings)
                    foreach (var d in b.BookingDetails) d.CourtName = courtNameLookup.GetValueOrDefault(d.CourtId, $"Sân {d.CourtId}");

                // Map tên sân cho Children
                foreach (var b in bookingChildren)
                    foreach (var d in b.BookingDetails) d.CourtName = courtNameLookup.GetValueOrDefault(d.CourtId, $"Sân {d.CourtId}");


                var allDiscountIds = dailyBookings.Where(b => b.DiscountId.HasValue).Select(b => b.DiscountId.Value)
                                    .Concat(monthlyBookings.Where(b => b.DiscountId.HasValue).Select(b => b.DiscountId.Value))
                                    .Distinct().ToList();
                var discountLookup = new Dictionary<int, ReadDiscountDTO>();
                if (allDiscountIds.Any())
                {
                    var tasks = allDiscountIds.Select(id => _discountService.GetDiscountByIdAsync(id));
                    var results = await Task.WhenAll(tasks);
                    foreach (var d in results.Where(x => x != null)) discountLookup[d.Id] = d;
                }

                // ==================================================================================
                // 4. MAP DATA VÀO VIEWMODEL
                // ==================================================================================
                var currentUser = await _userService.GetUsersByIdsAsync(new List<int> { userId.Value }, accessToken);
                var userProfile = currentUser?.FirstOrDefault() ?? new PublicUserProfileDTO { FullName = "Người dùng" };

                // Map Daily
                foreach (var booking in dailyBookings)
                {
                    viewModel.DailyBookings.Add(new DailyBookingWithUserViewModel
                    {
                        Booking = booking,
                        User = userProfile,
                        Discount = booking.DiscountId.HasValue ? discountLookup.GetValueOrDefault(booking.DiscountId.Value) : null
                    });
                }

                // Map Monthly & Children (LOGIC CŨ CỦA BẠN ĐÂY)
                if (!isAjax)
                {
                    // Gom nhóm booking con theo MonthlyID
                    var bookingsInMonthlyPlan = bookingChildren
                        .Where(b => b.MonthlyBookingId != null)
                        .GroupBy(b => b.MonthlyBookingId.Value)
                        .ToDictionary(g => g.Key, g => g.ToList());

                    foreach (var mb in monthlyBookings)
                    {
                        viewModel.MonthlyBookings.Add(new MonthlyBookingWithDetailsViewModel
                        {
                            MonthlyBooking = mb,
                            User = userProfile,
                            // Lấy list con từ dictionary đã gom nhóm ở trên
                            Bookings = bookingsInMonthlyPlan.GetValueOrDefault(mb.Id, new List<BookingReadDto>()),
                            Discount = mb.DiscountId.HasValue ? discountLookup.GetValueOrDefault(mb.DiscountId.Value) : null
                        });
                    }
                }

                // Thông tin phân trang
                ViewBag.CurrentPage = page;
                ViewBag.TotalPages = (int)Math.Ceiling((double)dailyTotalCount / pageSize);

                if (isAjax) return PartialView("_DailyBookingTable", viewModel);
                return View("BookingHistory", viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Lỗi: " + ex.Message;
                return isAjax ? BadRequest() : RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMonthlyBookingForCheckout(int monthlyBookingId)
        {
            var accessToken = GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { message = "Phiên đăng nhập đã hết hạn." });
            }

            var monthlyBooking = await _bookingService.GetMonthlyBookingDetailAsync(accessToken, monthlyBookingId);
            if (monthlyBooking == null)
            {
                return NotFound(new { message = "Không tìm thấy gói đặt sân hàng tháng." });
            }
            
            var allDays = monthlyBooking.Bookings
                .Select(b => b.Date.Day)
                .Distinct()
                .OrderBy(d => d)
                .ToList();

            var allCourtIds = monthlyBooking.Bookings
                .SelectMany(b => b.BookingDetails)
                .Select(bd => bd.CourtId)
                .Distinct()
                .OrderBy(id => id)
                .ToList();

            var checkoutData = new
            {
                MonthlyBookingId = monthlyBooking.Id,
                Type = "month",
                StadiumId = monthlyBooking.StadiumId,
                Year = monthlyBooking.Year,
                Month = monthlyBooking.Month,
                SelectedDays = string.Join(",", allDays),
                StartTime = monthlyBooking.StartTime.Hours,
                EndTime = monthlyBooking.EndTime.Hours,
                SelectedCourtIds = string.Join(",", allCourtIds),
                TotalPrice = monthlyBooking.OriginalPrice,
                AfterPrice = monthlyBooking.TotalPrice,
                DiscountId = monthlyBooking.DiscountId
            };

            return Ok(checkoutData);
        }

        #region Private Helper Methods
        private string? GetAccessToken()
        {
            var sessionToken = HttpContext.Session.GetString("AccessToken");
            if (!string.IsNullOrEmpty(sessionToken))
            {
                return sessionToken;
            }
            
            return Request.Cookies["AccessToken"];
        }

        private string GetIpAddress()
        {
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
            
            ViewBag.CourtIdsString = courtId;
            
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
        public IActionResult MonthlyCheckout(MonthlyBookingFormViewModel model, string? courtNames)
        {
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
            ViewBag.CourtNames = courtNames; 
            
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
                        
                        if (discount.PercentValue != 100)
                        {
                            var calculatedDiscount = originalTotalPrice / (1m - ((decimal)discount.PercentValue / 100m)) * ((decimal)discount.PercentValue / 100m);
                            
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
                            discountAmount = originalTotalPrice;
                        }
                        
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
                Console.WriteLine($"[BookingDetail] Lỗi xảy ra: {ex.Message}");
                TempData["ErrorMessage"] = "Lỗi khi lấy chi tiết booking.";
                return RedirectToAction("BookingHistory");
            }
        }
        
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
            if (string.IsNullOrEmpty(stadiumId))
            {
                return RedirectToAction("Booking");
            }
            
            ViewBag.StadiumId = stadiumId;
            ViewBag.RestoreDate = date;
            ViewBag.RestoreStartTime = startTime;
            ViewBag.RestoreEndTime = endTime;
            ViewBag.RestoreCourtIds = courtIds;
            
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
            if (string.IsNullOrEmpty(stadiumId))
            {
                return RedirectToAction("MonthlyBooking");
            }
            
            ViewBag.StadiumId = stadiumId;
            ViewBag.RestoreYear = year;
            ViewBag.RestoreMonth = month; 
            ViewBag.RestoreSelectedDays = selectedDays;
            ViewBag.RestoreSelectedCourtIds = selectedCourtIds;
            ViewBag.RestoreStartTime = startTime;
            ViewBag.RestoreEndTime = endTime;
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetBookedCourts(int stadiumId, DateTime date, int startHour, int endHour)
        {
            var startTime = date.Date.AddHours(startHour);
            var endTime = date.Date.AddHours(endHour);
            
            var bookings = await _bookingService.GetBookedCourtsAsync(stadiumId, startTime, endTime);
            
            if (bookings != null)
            {
                foreach (var booking in bookings)
                {
                    if (booking.BookingDetails == null) continue;
                    
                    booking.BookingDetails = booking.BookingDetails
                        .Where(detail =>
                            detail.StartTime < endTime && detail.EndTime > startTime
                        )
                        .ToList();
                }
                
                var filteredResult = bookings.Where(b => b.BookingDetails != null && b.BookingDetails.Any()).ToList();
                
                return Json(filteredResult);
            }
            
            return Json(new List<BookingReadDto>());
        }

        [HttpGet]
        public async Task<IActionResult> GetBookedCourtsByDay(int stadiumId, DateTime date)
        {
            var result = await _bookingService.GetBookedCourtsAsync(stadiumId, date);
            return Json(result);
        }
        
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
                return RedirectToAction("VisuallyBooking");
            }
            
            ViewBag.StadiumId = stadiumId;
            
            ViewBag.RestoreDate = date;
            ViewBag.RestoreCourts = courts;
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            
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
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        [HttpGet]
        public async Task<List<BookingReadDto>> FilterByDateAndHour(int year, int month, List<int> days, int startTime,
            int endTime)
        {
            string startTimeStr = $"{startTime:D2}:00"; 
            string endTimeStr = $"{endTime:D2}:00";

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

                var bookings = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BookingReadDto>>(data);
                
                foreach (var booking in bookings)
                {
                    if (booking.BookingDetails == null) continue;
                    
                    booking.BookingDetails = booking.BookingDetails
                        .Where(detail =>
                        {
                            var detailStartTime = detail.StartTime;
                            
                            return detailStartTime.Year == year &&
                                   detailStartTime.Month == month &&
                                   days.Contains(detailStartTime.Day) &&
                                   detailStartTime.Hour >= startTime &&
                                   detailStartTime.Hour < endTime;
                        })
                        .ToList();
                }
                
                var filteredResult = bookings.Where(b => b.BookingDetails != null && b.BookingDetails.Any()).ToList();

                return filteredResult;
            }
        }

        [HttpGet]
        public async Task<IActionResult> FilterByCourtAndHour([FromQuery] List<int> courtIds, int year, int month, int startTime, int endTime)
        {
            try
            {
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
                var createdMonthlyBooking = await _bookingService.CreateMonthlyBookingAsync(bookingDto, accessToken);

                if (createdMonthlyBooking != null)
                {
                    HttpContext.Session.SetInt32("MonthlyBookingId", createdMonthlyBooking.Id);
                    HttpContext.Session.SetString("AccessToken", accessToken);
                    
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

                    // --- BẮT ĐẦU ĐOẠN CODE MỚI: LƯU SESSION ---
                    var sessionData = new PendingPaymentSessionDto
                    {
                        BookingId = createdMonthlyBooking.Id,
                        Type = "Monthly",
                        PaymentUrl = paymentUrl,
                        ExpireTime = DateTime.Now.AddMinutes(5)
                    };

                    string jsonSessionData = System.Text.Json.JsonSerializer.Serialize(sessionData);

                    // Key ví dụ: "Payment_Monthly_55"
                    HttpContext.Session.SetString($"Payment_Monthly_{createdMonthlyBooking.Id}", jsonSessionData);

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
                var startDateIso = startDate.ToString("yyyy-MM-ddT00:00:00Z");
                var endDateIso = endDate.ToString("yyyy-MM-ddT23:59:59Z");
                var userId = HttpContext.Session.GetInt32("UserId");
                
                var queryString = $"?$filter=UserId eq {userId} and Date ge {startDateIso} and Date le {endDateIso} and (Status eq 'accepted' or Status eq 'waiting' or Status eq 'completed')&$expand=BookingDetails&$orderby=Date asc";
                var bookings = (await _bookingService.GetBookingAsync(accessToken, queryString)).Data;

                if (bookings == null)
                {
                    return NotFound(new { message = "Không tìm thấy booking nào." });
                }
                
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetBookingsForWeek] Lỗi: {ex.Message}");
                return StatusCode(500, new { message = "Lỗi server khi lấy dữ liệu booking." });
            }
        }
        
        // Trong BookingController.cs
        [HttpGet]
        public async Task<IActionResult> CheckCompletedBooking(int stadiumId)
        {
            try
            {
                // 1. Lấy AccessToken từ Cookie
                var accessToken = GetAccessToken();
        
                if (string.IsNullOrEmpty(accessToken))
                {
                    // Nếu chưa đăng nhập, mặc định là chưa có booking hoàn thành
                    return Json(new { success = false, hasCompleted = false, message = "User not logged in" });
                }

                // 2. Gọi Service để kiểm tra
                // Đảm bảo bạn đã Inject IBookingService vào Controller này
                bool result = await _bookingService.HasCompletedBookingAtStadiumAsync(accessToken, stadiumId);

                // 3. Trả kết quả về View
                return Json(new { success = true, hasCompleted = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, hasCompleted = false, message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult RetryPayment(int id, string type)
        {
            string sessionKey = type == "Single" ? $"Payment_Single_{id}" : $"Payment_Monthly_{id}";
            string jsonSessionData = HttpContext.Session.GetString(sessionKey);

            if (string.IsNullOrEmpty(jsonSessionData))
            {
                TempData["ErrorMessage"] = "Link thanh toán không tìm thấy hoặc đã quá hạn.";
                return RedirectToAction("Index", "Home");
            }

            var paymentData = System.Text.Json.JsonSerializer.Deserialize<PendingPaymentSessionDto>(jsonSessionData);

            if (DateTime.Now > paymentData.ExpireTime)
            {
                HttpContext.Session.Remove(sessionKey);
                TempData["ErrorMessage"] = "Link thanh toán đã hết hạn (quá 5 phút). Vui lòng đặt lại.";
                // Redirect về trang lịch sử để refresh lại giao diện
                return RedirectToAction("HistoryBooking");
            }


            var accessToken = GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
                return RedirectToAction("Login", "Common");
            if (!string.IsNullOrEmpty(accessToken))
            {
                HttpContext.Session.SetString("AccessToken", accessToken);
            }

            // 2. Restore ID theo đúng loại và xóa ID của loại kia để tránh nhầm lẫn
            if (paymentData.Type == "Single")
            {
                HttpContext.Session.SetInt32("BookingId", paymentData.BookingId);
                HttpContext.Session.Remove("MonthlyBookingId"); // Xóa Monthly nếu có
            }
            else // Monthly
            {
                HttpContext.Session.SetInt32("MonthlyBookingId", paymentData.BookingId);
                HttpContext.Session.Remove("BookingId"); // Xóa Single nếu có
            }
            // ---------------------------------------------------------------------------

            return Redirect(paymentData.PaymentUrl);
        }
    }
}