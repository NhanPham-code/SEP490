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

        public BookingController(IBookingService bookingService, ITokenService tokenService)
        {
            _bookingService = bookingService;
            _tokenService = tokenService;
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

        public IActionResult Booking()
        {
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
    }
}
