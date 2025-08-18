using DTOs.BookingDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace CustomerUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public BookingController(IBookingService bookingService, ITokenService tokenService, IUserService userService)
        {
            _bookingService = bookingService;
            _tokenService = tokenService;
            _userService = userService;
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
        public IActionResult Checkout(string date, int startTime, int endTime, decimal totalPrice, string courtId, string stadiumId)
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

                // Log dữ liệu booking ra console
                if (bookings != null && bookings.Count > 0)
                {
                    Console.WriteLine($"[BookingHistory] Đã lấy được {bookings.Count} booking(s):");
                    foreach (var b in bookings)
                    {
                        Console.WriteLine($" - Booking Id: {b.Id}, Date: {b.Date}");
                    }
                }
                else
                {
                    Console.WriteLine("[BookingHistory] Không có booking nào được trả về.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[BookingHistory] Lỗi khi lấy lịch sử booking: " + ex.Message);
                TempData["ErrorMessage"] = "Lỗi khi lấy lịch sử booking.";
                bookings = new List<BookingReadDto>();
            }

            return View(bookings);
        }

        /*public IActionResult Booking()
        {
            return View();
        }*/

        public IActionResult Booking(string stadiumId)
        {
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

                TempData["SuccessMessage"] = "Đặt sân thành công!";
                TempData["BookingId"] = createdBooking.Id;
                return RedirectToAction("Index", "Home");
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
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized();

            var startTime = date.Date.AddHours(startHour);
            var endTime = date.Date.AddHours(endHour);

            var result = await _bookingService.GetBookedCourtsAsync(accessToken, stadiumId, startTime, endTime);
            return Json(result);
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
    }
}
