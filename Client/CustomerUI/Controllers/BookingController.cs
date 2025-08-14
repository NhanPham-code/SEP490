using DTOs.BookingDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace CustomerUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
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

            // Bạn vẫn có thể tách ra danh sách để dùng cho logic khác nếu cần
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
                    // Redirect về trang trước với thông báo lỗi
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

                // Thành công - chuyển đến trang xác nhận hoặc danh sách booking
                TempData["SuccessMessage"] = "Đặt sân thành công!";
                TempData["BookingId"] = createdBooking.Id;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                TempData["ErrorMessage"] = $"Có lỗi xảy ra: {ex.Message}";
                return RedirectToAction("Checkout");
            }
        }
    }
}
