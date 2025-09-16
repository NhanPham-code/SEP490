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
        public BookingController(
            IBookingService bookingService,
            ITokenService tokenService,
            IUserService userService,
            IDiscountService discountService,
            IStadiumService stadiumService,
            ICourtRelationService courtRelationService)
        {
            _bookingService = bookingService;
            _tokenService = tokenService;
            _userService = userService;
            _discountService = discountService;
            _stadiumService = stadiumService;
            _courtRelationService = courtRelationService;
        }


        private string? GetAccessToken()
        {
            return Request.Cookies["AccessToken"];
        }

        private string? GetRefreshToken()
        {
            return Request.Cookies["RefreshToken"];
        }

        [HttpPost]
        public IActionResult Checkout([FromForm] CheckoutRequest request)
        {
            ViewBag.Date = request.Date;
            ViewBag.TotalPrice = request.TotalPrice;
            ViewBag.StadiumId = request.StadiumId;
            ViewBag.Courts = request.Courts;

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

            // Trả về view cho trang checkout hàng tháng
            return View();
        }


        public async Task<IActionResult> BookingHistory()
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();

            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Bạn chưa đăng nhập hoặc phiên đã hết hạn.";
                return RedirectToAction("Login", "Common");
            }

            List<BookingReadDto> bookings;
            try
            {
                bookings = await _bookingService.GetBookingHistoryAsync(accessToken);

                if (bookings != null && bookings.Count > 0)
                {
                    var stadiumIds = bookings.Select(b => b.StadiumId).Distinct().ToList();
                    var stadiumNames = new Dictionary<int, string>();
                    foreach (var id in stadiumIds)
                    {
                        var stadium = await _stadiumService.GetStadiumByIdAsync(id);
                        if (stadium != null)
                        {
                            stadiumNames[id] = stadium.Name;
                        }
                    }
                    ViewBag.StadiumNames = stadiumNames;

                    // Tạo dictionary để lưu thông tin giảm giá
                    var discountInfo = new Dictionary<int, string>();
                    foreach (var booking in bookings)
                    {
                        if (booking.DiscountId.HasValue)
                        {
                            // Gọi API để lấy thông tin chi tiết mã giảm giá
                            var discount = await _discountService.GetDiscountByIdAsync(booking.DiscountId.Value);
                            if (discount != null)
                            {
                                discountInfo[booking.Id] = $"Giảm {discount.PercentValue}%";
                            }
                            else
                            {
                                discountInfo[booking.Id] = "Mã không hợp lệ";
                            }
                        }
                        else
                        {
                            discountInfo[booking.Id] = "Không áp dụng";
                        }
                    }
                    ViewBag.DiscountInfo = discountInfo;
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Lỗi khi lấy lịch sử booking.";
                bookings = new List<BookingReadDto>();
            }

            return View(bookings);
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
                return Unauthorized();
            }

            try
            {
                var discounts = await _discountService.GetDiscountsByStadiumIdAsync(stadiumId);
                if (discounts == null)
                {
                    return NotFound(new { message = "Không tìm thấy mã giảm giá nào cho sân vận động này." });
                }
                return Ok(discounts);
            }
            catch (Exception ex)
            {
                // Log lỗi
                Console.WriteLine($"[GetDiscounts] Lỗi khi lấy danh sách giảm giá: {ex.Message}");
                return StatusCode(500, new { message = "Lỗi server khi lấy danh sách giảm giá." });
            }
        }

        /*public IActionResult Booking()
        {
            return View();
        }*/

        public IActionResult Booking(string stadiumId)
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

            // Trả về cùng một View "Booking.cshtml".
            return View();
        }

        public IActionResult MonthlyBooking(string stadiumId)
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

            // Trả về cùng một View "Booking.cshtml".
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingCreateDto bookingDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["ErrorMessage"] = "Thông tin đặt sân không hợp lệ. Vui lòng thử lại.";
                    return RedirectToAction("Checkout");
                }

                var accessToken = GetAccessToken();
                if (string.IsNullOrEmpty(accessToken))
                {
                    return RedirectToAction("Login", "Common");
                }

                var createdBooking = await _bookingService.CreateBookingAsync(bookingDto, accessToken);

                if (createdBooking == null)
                {
                    TempData["ErrorMessage"] = "Không thể tạo booking. Vui lòng thử lại.";
                    return RedirectToAction("Checkout");
                }

                TempData["BookingSuccess"] = true;
                TempData["SuccessMessage"] = "Đặt sân thành công!";

                // Thay vì chỉ RedirectToAction, hãy thêm tham số truy vấn
                return RedirectToAction("BookingHistory");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Có lỗi xảy ra: {ex.Message}";
                return RedirectToAction("Checkout");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBookedCourts(int stadiumId, DateTime date, int startHour, int endHour)
        {
            //var accessToken = _tokenService.GetAccessTokenFromCookie();
            //if (string.IsNullOrEmpty(accessToken))
            //    return Unauthorized();

            var startTime = date.Date.AddHours(startHour);
            var endTime = date.Date.AddHours(endHour);

            var result = await _bookingService.GetBookedCourtsAsync(stadiumId, startTime, endTime);
            return Json(result);
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

        public IActionResult VisuallyBooking(string stadiumId)
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
        public async Task<IActionResult> FilterByDateAndHour(int year, int month, List<int> days, int startTime, int endTime)
        {
            try
            {
                var result = await _bookingService.FilterByDateAndHour(year, month, days, startTime, endTime);

                // Debug logging
                Console.WriteLine($"Service returned: {result?.GetType().Name}");

                // Make sure we're returning the correct JSON structure
                return Ok(result); // Use Ok() instead of Json() to ensure proper serialization
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in FilterByDateAndHour: {ex.Message}");
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> FilterByCourtAndHour([FromQuery] List<int> courtIds, int year, int month, int startTime, int endTime)
        {
            try
            {
                if (courtIds == null || !courtIds.Any())
                {
                    return BadRequest(new { error = "Cần cung cấp ít nhất một Court ID." });
                }

                var result = await _bookingService.FilterByCourtAndHour(courtIds, year, month, startTime, endTime);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in FilterByCourtAndHour: {ex.Message}");
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
