using DTOs.BookingDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

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

                // Log dữ liệu booking ra console (mỗi booking in ra Id và một số trường cơ bản)
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

    }
}
