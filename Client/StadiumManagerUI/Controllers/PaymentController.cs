using DTOs.BookingDTO;
using DTOs.Helpers;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using StadiumManagerUI.Helpers; // Đảm bảo bạn có using VnPayLibrary ở đây

namespace StadiumUI.Controllers
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

            // Lấy thông tin từ Session
            var accessToken = HttpContext.Session.GetString("AccessToken");
            int? bookingIdForUpdate = HttpContext.Session.GetInt32("BookingIdToUpdate");
            string? bookingTypeForUpdate = HttpContext.Session.GetString("BookingType");
            string? finalStatusForUpdate = HttpContext.Session.GetString("FinalStatus");

            // Xác định xem đây là callback cho việc gì
            bool isCancellationFeePayment = bookingIdForUpdate.HasValue && !string.IsNullOrEmpty(bookingTypeForUpdate) && !string.IsNullOrEmpty(finalStatusForUpdate);


            string redirectAction = "BookingManager" ;
            string redirectController = "Booking";

            if (string.IsNullOrEmpty(accessToken) || (!isCancellationFeePayment))
            {
                TempData["ErrorMessage"] = "Phiên làm việc đã hết hạn hoặc dữ liệu không hợp lệ.";
                return RedirectToAction(redirectAction, redirectController);
            }

            if (isPaymentSuccess)
            {
                try
                {
                    if (isCancellationFeePayment)
                    {
                        // Xử lý thanh toán phí hủy/từ chối
                        await HandleCancellationFeePayment(bookingIdForUpdate.Value, bookingTypeForUpdate, finalStatusForUpdate, accessToken);
                        TempData["SuccessMessage"] = "Thanh toán phí và cập nhật trạng thái thành công!";
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Đã xảy ra lỗi khi cập nhật đơn đặt sân: {ex.Message}";
                }
            }


            // Xóa tất cả các key session đã sử dụng
            HttpContext.Session.Remove("AccessToken");
            HttpContext.Session.Remove("BookingIdToUpdate");
            HttpContext.Session.Remove("BookingType");
            HttpContext.Session.Remove("FinalStatus");

            return RedirectToAction(redirectAction, redirectController);
        }
        //// Thêm hàm này vào BookingController

        ///// <summary>
        ///// Xử lý cập nhật trạng thái hủy/từ chối cho Daily hoặc Monthly Booking sau khi đã xác định không cần thanh toán phí hoặc đã thanh toán thành công.
        ///// </summary>
        //private async Task<IActionResult> HandleCancellation(int bookingId, string bookingType, string finalStatus, string accessToken)
        //{
        //    if ("Monthly".Equals(bookingType, StringComparison.OrdinalIgnoreCase))
        //    {
        //        // Lấy lại DTO của Monthly Booking để update
        //        var monthlyBooking = (await _bookingService.GetMonthlyBookingAsync(accessToken, $"?$filter=Id eq {bookingId}")).FirstOrDefault();
        //        if (monthlyBooking == null)
        //            return NotFound(new { message = "Không tìm thấy lịch đặt tháng." });

        //        // Tạo DTO cập nhật, chỉ thay đổi Status và giữ nguyên các trường cần thiết khác
        //        var updateDto = new MonthlyBookingUpdateDto
        //        {
        //            Status = finalStatus,
        //            TotalPrice = monthlyBooking.TotalPrice,
        //            PaymentMethod = monthlyBooking.PaymentMethod,
        //            OriginalPrice = monthlyBooking.OriginalPrice,
        //            Note = monthlyBooking.Note,
        //            // Thêm các trường khác nếu cần thiết để đảm bảo tính toàn vẹn của DTO
        //        };

        //        var updatedMonthlyBooking = await _bookingService.UpdateMonthlyBookingAsync(bookingId, updateDto, accessToken);
        //        if (updatedMonthlyBooking == null)
        //            return BadRequest(new { message = "Cập nhật lịch đặt tháng thất bại." });

        //        try
        //        {
        //            // Đồng bộ trạng thái các booking con
        //            var childBookings = await _bookingService.GetBookingAsync(accessToken, $"?$filter=MonthlyBookingId eq {bookingId}");
        //            if (childBookings != null && childBookings.Any())
        //            {
        //                foreach (var child in childBookings)
        //                {
        //                    // Tạo DTO cập nhật cho booking con
        //                    var childUpdateDto = new BookingUpdateDto
        //                    {
        //                        Status = finalStatus,
        //                        // Giữ nguyên các trường cần thiết khác của booking con
        //                        UserId = child.UserId,
        //                        StadiumId = child.StadiumId,
        //                        Date = child.Date,
        //                        TotalPrice = child.TotalPrice,
        //                        OriginalPrice = child.OriginalPrice,
        //                        Note = child.Note,
        //                        DiscountId = child.DiscountId
        //                        // Thêm các trường khác nếu cần thiết
        //                    };
        //                    await _bookingService.UpdateBookingAsync(child.Id, childUpdateDto, accessToken);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Lỗi khi đồng bộ các lịch đặt con cho MonthlyBookingId {bookingId}: {ex.Message}");
        //            // Có thể chọn trả về lỗi hoặc chỉ log lỗi tùy theo yêu cầu nghiệp vụ
        //            return Ok(new { success = true, booking = updatedMonthlyBooking, warning = "Cập nhật lịch cha thành công, nhưng thất bại khi đồng bộ các lịch con." });
        //        }

        //        return Json(new { success = true, booking = updatedMonthlyBooking });
        //    }
        //    else // Daily booking
        //    {
        //        var booking = (await _bookingService.GetBookingAsync(accessToken, $"?$filter=Id eq {bookingId}")).FirstOrDefault();
        //        if (booking == null)
        //            return NotFound(new { message = "Không tìm thấy lịch đặt ngày." });

        //        // Tạo DTO cập nhật, chỉ thay đổi Status và giữ nguyên các trường cần thiết khác
        //        var updateDto = new BookingUpdateDto
        //        {
        //            Status = finalStatus,
        //            // Giữ nguyên các trường cần thiết khác
        //            UserId = booking.UserId,
        //            StadiumId = booking.StadiumId,
        //            Date = booking.Date,
        //            TotalPrice = booking.TotalPrice,
        //            OriginalPrice = booking.OriginalPrice,
        //            Note = booking.Note,
        //            DiscountId = booking.DiscountId
        //            // Thêm các trường khác nếu cần thiết
        //        };

        //        var updated = await _bookingService.UpdateBookingAsync(bookingId, updateDto, accessToken);
        //        if (updated == null)
        //            return BadRequest(new { message = "Cập nhật lịch đặt ngày thất bại." });

        //        return Json(new { success = true, booking = updated });
        //    }
        //}

        private async Task HandleCancellationFeePayment(int bookingId, string bookingType, string finalStatus, string accessToken)
        {
            if ("Monthly".Equals(bookingType, StringComparison.OrdinalIgnoreCase))
            {
                // Cần lấy lại DTO của Monthly Booking để update
                var monthlyBooking = (await _bookingService.GetMonthlyBookingAsync(accessToken, $"?$filter=Id eq {bookingId}")).FirstOrDefault();
                if (monthlyBooking == null) throw new Exception("Không tìm thấy lịch đặt tháng.");

                var updateDto = new MonthlyBookingUpdateDto
                {
                    Status = finalStatus,
                    TotalPrice = monthlyBooking.TotalPrice,
                    PaymentMethod = monthlyBooking.PaymentMethod,
                    OriginalPrice = monthlyBooking.OriginalPrice,
                    Note = monthlyBooking.Note,
                };
                await _bookingService.UpdateMonthlyBookingAsync(bookingId, updateDto, accessToken);

                // Đồng bộ các booking con
                var childBookings = await _bookingService.GetBookingAsync(accessToken, $"?$filter=MonthlyBookingId eq {bookingId}");
                foreach (var child in childBookings)
                {
                    var childUpdateDto = new BookingUpdateDto
                    {
                        Status = finalStatus,
                        // Thêm các trường còn thiếu từ logic gốc:
                        UserId = child.UserId,
                        StadiumId = child.StadiumId,
                        Date = child.Date,
                        TotalPrice = child.TotalPrice,
                        OriginalPrice = child.OriginalPrice,
                        Note = child.Note,
                        DiscountId = child.DiscountId
                    };
                    await _bookingService.UpdateBookingAsync(child.Id, childUpdateDto, accessToken);
                }
            }
            else // Daily booking
            {
                var booking = (await _bookingService.GetBookingAsync(accessToken, $"?$filter=Id eq {bookingId}")).FirstOrDefault();
                if (booking == null) throw new Exception("Không tìm thấy lịch đặt ngày.");

                var updateDto = new BookingUpdateDto { Status = finalStatus, UserId = booking.UserId, StadiumId = booking.StadiumId, Date = booking.Date, TotalPrice = booking.TotalPrice, OriginalPrice = booking.OriginalPrice, Note = booking.Note, DiscountId = booking.DiscountId };
                await _bookingService.UpdateBookingAsync(bookingId, updateDto, accessToken);
            }
        }
    }
}