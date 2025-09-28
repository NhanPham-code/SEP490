using DTOs.BookingDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Text.Json;
using DTOs.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using System;

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
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                    vnpay.AddResponseData(key, value);

            string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            string hashSecret = _configuration["VNPAY:HashSecret"];
            bool isPaymentSuccess = vnpay.ValidateSignature(hashSecret) && vnp_ResponseCode == "00";

            int? bookingId = HttpContext.Session.GetInt32("BookingId");
            var accessToken = HttpContext.Session.GetString("AccessToken");

            if (bookingId == null || string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Phiên làm việc đã hết hạn. Không xác định được đơn đặt sân để cập nhật.";
                return RedirectToAction("BookingHistory", "Booking");
            }

            // Lấy lại booking từ API
            string queryString = $"?$filter=Id eq {bookingId}";
            var bookings = await _bookingService.GetBookingAsync(accessToken, queryString);
            var booking = bookings.FirstOrDefault();

            if (booking == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy đơn đặt sân.";
                return RedirectToAction("BookingHistory", "Booking");
            }

            string finalStatus;

            if (isPaymentSuccess)
            {
                // Mặc định là "pending" nếu thanh toán thành công
                finalStatus = "pending";

                try
                {
                    // 1. Tạo query string để lấy lịch sử đặt sân của user tại sân vận động này
                    string historyQueryString = $"?$filter=UserId eq '{booking.UserId}' and StadiumId eq {booking.StadiumId}";

                    // 2. Gọi service để lấy lịch sử
                    List<BookingReadDto> historyBookings = await _bookingService.GetBookingAsync(accessToken, historyQueryString);

                    if (historyBookings != null)
                    {
                        // 3. Đếm tổng số booking và số booking đã hoàn thành
                        int totalBookings = historyBookings.Count;
                        int completedBookings = historyBookings.Count(b => "completed".Equals(b.Status, StringComparison.OrdinalIgnoreCase));

                        // 4. Tính toán tỷ lệ hoàn thành

                        double completionRate = (totalBookings > 0) ? (double)completedBookings / totalBookings : 0;

                        // 5. Kiểm tra điều kiện để nâng cấp trạng thái
                        if (totalBookings > 3 && completionRate >= 0.8)
                        {
                            finalStatus = "accepted"; // Nâng cấp trạng thái!
                            TempData["AutoAcceptedMessage"] = "Cảm ơn bạn là khách hàng thân thiết! Đơn đặt sân của bạn đã được tự động chấp nhận.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi khi kiểm tra lịch sử, hệ thống vẫn hoạt động bình thường
                    // và giữ trạng thái là "pending". Ghi log lại lỗi để kiểm tra sau.
                    // _logger.LogError(ex, "Error checking booking history for auto-approval.");
                }
            }
            else
            {
                // Nếu thanh toán thất bại
                finalStatus = "payfail";
            }

            var updateDto = new BookingUpdateDto
            {
                UserId = booking.UserId,
                StadiumId = booking.StadiumId,
                Status = finalStatus, // Sử dụng trạng thái đã được tính toán
                Date = booking.Date,
                TotalPrice = booking.TotalPrice,
                OriginalPrice = booking.OriginalPrice,
                Note = booking.Note,
                DiscountId = booking.DiscountId
            };

            try
            {
                await _bookingService.UpdateBookingAsync(bookingId.Value, updateDto, accessToken);

                if (finalStatus == "pending" || finalStatus == "accepted")
                {
                    TempData["BookingSuccess"] = true;
                    TempData["SuccessMessage"] = "Đặt sân và thanh toán thành công!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Thanh toán không thành công hoặc đã bị hủy.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Đã xảy ra lỗi khi cập nhật đơn đặt sân: {ex.Message}";
            }
            finally
            {
                HttpContext.Session.Remove("BookingId");
                HttpContext.Session.Remove("AccessToken"); // Cũng nên xóa token sau khi dùng
            }

            return RedirectToAction("BookingHistory", "Booking");
        }
        public async Task<IActionResult> MonthlyPaymentCallback()
        {
            var vnpay = new VnPayLibrary();
            var responseData = Request.Query.ToDictionary(k => k.Key, v => v.Value.ToString());

            foreach (var (key, value) in responseData)
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                    vnpay.AddResponseData(key, value);

            string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            string hashSecret = _configuration["VNPAY:HashSecret"];
            bool checkSignature = vnpay.ValidateSignature(hashSecret);

            int? monthlyBookingId = HttpContext.Session.GetInt32("MonthlyBookingId");
            var accessToken = HttpContext.Session.GetString("AccessToken");

            if (monthlyBookingId == null || string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Không xác định được booking hàng tháng để cập nhật.";
                return RedirectToAction("BookingHistory", "Booking");
            }

            // Lấy lại monthly booking từ API
            string queryString = $"?$filter=Id eq {monthlyBookingId}";
            var monthlyBookings = await _bookingService.GetMonthlyBookingAsync(accessToken, queryString);
            var monthlyBooking = monthlyBookings.FirstOrDefault();

            if (monthlyBooking == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy booking hàng tháng.";
                return RedirectToAction("BookingHistory", "Booking");
            }

            // Tạo DTO để cập nhật trạng thái
            var updateDto = new MonthlyBookingUpdateDto
            {
                Status = (checkSignature && vnp_ResponseCode == "00") ? "pending" : "canceled"
            };

            try
            {
                await _bookingService.UpdateMonthlyBookingAsync(monthlyBookingId.Value, updateDto, accessToken);

                if (updateDto.Status == "pending")
                {
                    TempData["SuccessMessage"] = "Đặt sân hàng tháng và thanh toán thành công!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Thanh toán không thành công hoặc bị hủy.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Đã xảy ra lỗi khi cập nhật booking: {ex.Message}";
            }
            finally
            {
                HttpContext.Session.Remove("MonthlyBookingId");
            }

            return RedirectToAction("BookingHistory", "Booking");
        }
    }
}