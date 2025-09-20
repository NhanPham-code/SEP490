using DTOs.BookingDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Text.Json;
using UserUI.Helpers;

namespace CustomerUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IConfiguration _configuration;

        public PaymentController(IBookingService bookingService, IConfiguration configuration)
        {
            _bookingService = bookingService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> PaymentCallback()
        {
            var vnpay = new VnPayLibrary();
            var responseData = Request.Query.ToDictionary(k => k.Key, v => v.Value.ToString());

            foreach (var (key, value) in responseData)
            {
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    vnpay.AddResponseData(key, value);
                }
            }

            string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            string hashSecret = _configuration["VNPAY:HashSecret"];
            bool checkSignature = vnpay.ValidateSignature(hashSecret);

            if (!checkSignature || vnp_ResponseCode != "00")
            {
                TempData["ErrorMessage"] = $"Lỗi thanh toán VNPay. Mã lỗi: {vnp_ResponseCode}";
                return RedirectToAction("BookingHistory", "Booking");
            }

            var bookingJson = HttpContext.Session.GetString("BookingData");
            var accessToken = HttpContext.Session.GetString("AccessToken");

            if (string.IsNullOrEmpty(bookingJson) || string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Phiên làm việc đã hết hạn hoặc không tìm thấy thông tin xác thực. Vui lòng thử lại.";
                return RedirectToAction("BookingHistory", "Booking");
            }

            var bookingDto = JsonSerializer.Deserialize<BookingCreateDto>(bookingJson);

            try
            {
                var createdBooking = await _bookingService.CreateBookingAsync(bookingDto, accessToken);
                if (createdBooking != null)
                {
                    TempData["BookingSuccess"] = true;
                    TempData["SuccessMessage"] = "Đặt sân và thanh toán thành công!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Không thể tạo booking sau khi thanh toán. Vui lòng liên hệ hỗ trợ.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Đã xảy ra lỗi: {ex.Message}";
            }
            finally
            {
                // **SỬA ĐỔI Ở ĐÂY**: Chỉ xóa dữ liệu booking, giữ lại AccessToken
                HttpContext.Session.Remove("BookingData");
            }

            return RedirectToAction("BookingHistory", "Booking");
        }
    }
}