using DTOs.BookingDTO;
using DTOs.Helpers;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using StadiumManagerUI.Helpers;
using System.Text.Json;

namespace StadiumManagerUI.Controllers
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
            bool isPaymentSuccess = vnpay.ValidateSignature(hashSecret) && vnp_ResponseCode == "00";

            var accessToken = HttpContext.Session.GetString("AccessToken");
            int? monthlyBookingId = HttpContext.Session.GetInt32("MonthlyBookingIdToUpdate");
            string? childIdsJson = HttpContext.Session.GetString("ChildBookingIdsToCancel");

            // Dọn dẹp session ngay sau khi lấy
            HttpContext.Session.Remove("AccessToken");
            HttpContext.Session.Remove("MonthlyBookingIdToUpdate");
            HttpContext.Session.Remove("ChildBookingIdsToCancel");

            if (!isPaymentSuccess)
            {
                TempData["ErrorMessage"] = "Thanh toán phí hủy không thành công. Lịch đặt chưa được thay đổi.";
                return RedirectToAction("BookingManager", "Booking");
            }

            if (string.IsNullOrEmpty(accessToken) || !monthlyBookingId.HasValue || string.IsNullOrEmpty(childIdsJson))
            {
                TempData["ErrorMessage"] = "Phiên thanh toán đã hết hạn hoặc dữ liệu không hợp lệ.";
                return RedirectToAction("BookingManager", "Booking");
            }

            try
            {
                var childBookingIdsToCancel = JsonSerializer.Deserialize<List<int>>(childIdsJson);
                if (childBookingIdsToCancel != null && childBookingIdsToCancel.Any())
                {
                    // **THỰC THI TOÀN BỘ LOGIC CẬP NHẬT TẠI ĐÂY**
                    await HandleSuccessfulCancellation(monthlyBookingId.Value, childBookingIdsToCancel, accessToken);
                    TempData["SuccessMessage"] = "Thanh toán phí và hủy lịch thành công!";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Đã xảy ra lỗi khi cập nhật sau thanh toán: {ex.Message}";
            }

            return RedirectToAction("BookingManager", "Booking");
        }

        // Action để xử lý trường hợp không có phí, được gọi từ BookingController
        [HttpGet]
        public async Task<IActionResult> HandleFreeCancellation()
        {
            var accessToken = TempData["AccessToken"] as string;
            var monthlyBookingId = (int?)TempData["MonthlyBookingId"];
            var childIdsJson = TempData["ChildIdsToCancel"] as string;

            if (string.IsNullOrEmpty(accessToken) || !monthlyBookingId.HasValue || string.IsNullOrEmpty(childIdsJson))
            {
                TempData["ErrorMessage"] = "Yêu cầu không hợp lệ.";
                return RedirectToAction("BookingManager", "Booking");
            }

            try
            {
                var childBookingIdsToCancel = JsonSerializer.Deserialize<List<int>>(childIdsJson);
                await HandleSuccessfulCancellation(monthlyBookingId.Value, childBookingIdsToCancel, accessToken);
                TempData["SuccessMessage"] = "Lịch đặt đã được hủy thành công (không có phí).";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Lỗi khi hủy: {ex.Message}";
            }

            return RedirectToAction("BookingManager", "Booking");
        }


        /// <summary>
        /// Hàm này chứa logic nghiệp vụ cốt lõi để cập nhật database sau khi đã chắc chắn việc hủy được phép diễn ra.
        /// </summary>
        private async Task HandleSuccessfulCancellation(int monthlyBookingId, List<int> childBookingIdsToCancel, string accessToken)
        {
            // 1. Cập nhật trạng thái các booking con thành "cancelled"
            foreach (var childId in childBookingIdsToCancel)
            {
                var booking = (await _bookingService.GetBookingAsync(accessToken, $"?$filter=Id eq {childId}")).FirstOrDefault();
                if (booking == null) continue;

                var childUpdateDto = new BookingUpdateDto
                {
                    Status = "cancelled",
                    // Sao chép lại các trường bắt buộc để tránh lỗi validation
                    UserId = booking.UserId,
                    StadiumId = booking.StadiumId,
                    Date = booking.Date,
                    TotalPrice = booking.TotalPrice,
                    OriginalPrice = booking.OriginalPrice,
                    Note = booking.Note,
                    DiscountId = booking.DiscountId
                };
                await _bookingService.UpdateBookingAsync(childId, childUpdateDto, accessToken);
            }

            // 2. Lấy lại toàn bộ booking con để tính toán lại cho booking tháng
            var allChildBookingsAfterUpdate = await _bookingService.GetBookingAsync(accessToken, $"?$filter=MonthlyBookingId eq {monthlyBookingId}");

            // 3. Tính toán lại tổng tiền mới cho booking tháng
            var newTotalPrice = allChildBookingsAfterUpdate
                .Where(b => !b.Status.Equals("cancelled", StringComparison.OrdinalIgnoreCase))
                .Sum(b => b.TotalPrice.GetValueOrDefault());

            // 4. Xác định trạng thái mới cho booking tháng
            var remainingActiveBookings = allChildBookingsAfterUpdate
                .Any(b => !b.Status.Equals("completed", StringComparison.OrdinalIgnoreCase) &&
                          !b.Status.Equals("cancelled", StringComparison.OrdinalIgnoreCase));

            var newMonthlyStatus = remainingActiveBookings ? "accepted" : "cancelled";

            // 5. Cập nhật booking tháng
            var monthlyBooking = (await _bookingService.GetMonthlyBookingAsync(accessToken, $"?$filter=Id eq {monthlyBookingId}")).FirstOrDefault();
            if (monthlyBooking == null) throw new Exception("Không tìm thấy lịch đặt tháng.");

            var updateDto = new MonthlyBookingUpdateDto
            {
                Status = newMonthlyStatus,
                TotalPrice = newTotalPrice,
                PaymentMethod = monthlyBooking.PaymentMethod,
                OriginalPrice = monthlyBooking.OriginalPrice,
                Note = monthlyBooking.Note,
            };
            await _bookingService.UpdateMonthlyBookingAsync(monthlyBookingId, updateDto, accessToken);

        }
    }
}