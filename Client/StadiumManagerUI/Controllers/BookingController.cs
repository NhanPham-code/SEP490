using DTOs.BookingDTO;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> BookingManager()
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
                var queryString = "";
                bookings = await _bookingService.GetBookingAsync(accessToken, queryString);

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
    }
}
