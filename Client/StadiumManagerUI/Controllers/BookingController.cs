using System.Drawing.Printing;
using System.Text.Json;
using DTOs.BookingDTO;
using DTOs.StadiumDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;

namespace StadiumManagerUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IBookingService _bookingService;
        private readonly IStadiumService _stadiumService;
        private readonly IDiscountService _discountService;

        public BookingController(ITokenService tokenService, IBookingService bookingService, IStadiumService stadiumService, IDiscountService discountService)
        {
            _tokenService = tokenService;
            _bookingService = bookingService;
            _stadiumService = stadiumService;
            _discountService = discountService;
        }

        // Action để hiển thị trang quản lý booking
        [HttpGet]
        public async Task<IActionResult> Bookings()
        {
            // 1. Xác thực người dùng
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login", "Account");
            }

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // 2. Lấy tất cả sân vận động của người dùng
            string stadiumFilter = $"&$filter=CreatedBy eq {userId}";
            var stadiumsJson = await _stadiumService.SearchStadiumAsync(stadiumFilter);

            var stadiums = new List<ReadStadiumDTO>();
            if (!string.IsNullOrEmpty(stadiumsJson))
            {
                try
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    // Giả sử service trả về JSON có dạng { "value": [...] }
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
                    // Xử lý lỗi nếu có, ví dụ hiển thị trang lỗi
                    ViewBag.ErrorMessage = $"Lỗi khi lấy dữ liệu sân vận động: {ex.Message}";
                    return View("Error");
                }
            }

            var bookings = new List<BookingReadDto>();
            if (stadiums.Any())
            {
                // 3. Tạo câu truy vấn OData để lấy booking
                var stadiumIds = stadiums.Select(s => s.Id);
                var filterClauses = stadiumIds.Select(id => $"StadiumId eq {id}");
                string bookingFilter = string.Join(" or ", filterClauses);

                // Thêm $expand để lấy chi tiết đặt sân
                string odataQueryString = $"?$filter={bookingFilter}&$expand=BookingDetails";

                // 4. Gọi API để lấy danh sách booking
                bookings = await _bookingService.GetBookingAsync(accessToken, odataQueryString);
            }

            // 5. Chuẩn bị ViewModel để truyền dữ liệu cho View
            // Thay đổi ở đây:
            // 1. Lưu danh sách stadiums vào ViewBag
            ViewBag.Stadiums = stadiums;

            // 2. Truyền trực tiếp danh sách bookings làm Model cho View
            return View(bookings);
        }
    }
}