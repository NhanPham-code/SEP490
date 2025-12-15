using DTOs.BookingDTO;
using DTOs.Helpers;
using DTOs.NotificationDTO;
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
        private readonly INotificationService _notificationService;
        private readonly IStadiumService _stadiumService;
        private readonly IUserService _userService; 
        private readonly IEmailService _emailService;


        public PaymentController(
            IBookingService bookingService,
            IConfiguration configuration,
            INotificationService notificationService,
            IStadiumService stadiumService,
            IUserService userService, 
            IEmailService emailService) 
        {
            _bookingService = bookingService;
            _configuration = configuration;
            _notificationService = notificationService;
            _stadiumService = stadiumService;
            _userService = userService;
            _emailService = emailService;
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

            if (!isPaymentSuccess)
            {
                TempData["ErrorMessage"] = "Thanh toán phí hủy không thành công. Lịch đặt chưa được thay đổi.";
                return RedirectToAction("BookingManager", "Booking");
            }

            // Lấy thông tin chung từ Session
            var accessToken = HttpContext.Session.GetString("AccessToken");
            var bookingType = HttpContext.Session.GetString("BookingType");

            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(bookingType))
            {
                TempData["ErrorMessage"] = "Phiên thanh toán đã hết hạn hoặc dữ liệu không hợp lệ.";
                return RedirectToAction("BookingManager", "Booking");
            }

            try
            {
                // Dựa vào BookingType để quyết định luồng xử lý
                if (bookingType == "Daily")
                {
                    int? bookingId = HttpContext.Session.GetInt32("BookingIdToUpdate");
                    string? finalStatus = HttpContext.Session.GetString("FinalStatus");
                    if (bookingId.HasValue && !string.IsNullOrEmpty(finalStatus))
                    {
                        await HandleDailySuccessfulCancellation(bookingId.Value, finalStatus, accessToken);
                        TempData["SuccessMessage"] = "Thanh toán phí và hủy lịch thành công!";
                    }
                }
                else if (bookingType == "Monthly")
                {
                    int? monthlyBookingId = HttpContext.Session.GetInt32("MonthlyBookingIdToUpdate");
                    string? childIdsJson = HttpContext.Session.GetString("ChildBookingIdsToCancel");
                    if (monthlyBookingId.HasValue && !string.IsNullOrEmpty(childIdsJson))
                    {
                        var childBookingIdsToCancel = JsonSerializer.Deserialize<List<int>>(childIdsJson);
                        await HandleMonthlySuccessfulCancellation(monthlyBookingId.Value, childBookingIdsToCancel, accessToken);
                        TempData["SuccessMessage"] = "Thanh toán phí và hủy gói đặt sân thành công!";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Đã xảy ra lỗi khi cập nhật sau thanh toán: {ex.Message}";
            }
            finally
            {
                // Dọn dẹp session
                HttpContext.Session.Clear();
            }

            return RedirectToAction("BookingManager", "Booking");
        }


        // --- HÀM 1: XỬ LÝ HỦY LỊCH LẺ ---
        private async Task HandleDailySuccessfulCancellation(int bookingId, string status, string accessToken)
        {
            var booking = (await _bookingService.GetBookingAsync(accessToken, $"?$filter=Id eq {bookingId}")).Data.FirstOrDefault();
            if (booking == null) throw new Exception($"Booking với ID {bookingId} không tồn tại.");

            // Update Status
            var updateDto = new BookingUpdateDto { Status = status, UserId = booking.UserId, StadiumId = booking.StadiumId, Date = booking.Date, TotalPrice = booking.TotalPrice, OriginalPrice = booking.OriginalPrice, Note = booking.Note, DiscountId = booking.DiscountId };
            await _bookingService.UpdateBookingAsync(bookingId, updateDto, accessToken);

            // Lấy thông tin Sân
            var stadium = await _stadiumService.GetStadiumByIdAsync(booking.StadiumId);
            var stadiumName = stadium?.Name ?? "sân";

            // Gửi Notification
            var notificationDto = new CreateNotificationDto
            {
                UserId = booking.UserId,
                Type = "Booking.Cancel",
                Title = "Lịch đặt sân đã bị hủy",
                Message = $"Lịch đặt của bạn tại sân '{stadiumName}' vào ngày {booking.Date:dd/MM/yyyy} đã được hủy.",
                Parameters = JsonSerializer.Serialize(new { bookingType = "daily", bookingId }),
            };
            await _notificationService.SendNotificationToUserAsync(notificationDto);

            // ✅ GỬI EMAIL (CẬP NHẬT)
            var user = await _userService.GetOtherUserByIdAsync(booking.UserId);

            if (user != null && !string.IsNullOrEmpty(user.Email))
            {
                string reason = status == "denied" ? "Chủ sân từ chối lịch đặt" : "Lịch đặt đã bị hủy";
                string subject = $"[Sportivey] Thông báo hủy lịch đặt sân #{booking.Id}";

                string messageBody = $@"
            <p>Xin chào <strong>{user.FullName}</strong>,</p>
            <p>Lịch đặt sân của bạn tại <strong>{stadiumName}</strong> đã bị hủy.</p>
            <ul>
                <li><strong>Ngày:</strong> {booking.Date:dd/MM/yyyy}</li>
                <li><strong>Lý do:</strong> {reason}</li>
            </ul>
            <p>Vui lòng liên hệ chủ sân để biết thêm chi tiết.</p>
        ";

                // Link trỏ về Customer Portal (Port 7128)
                string actionLink = "https://localhost:7128/Booking/BookingHistory";

                await _emailService.SendEmailAsync(user.Email, subject, messageBody, actionLink, "Xem Chi Tiết");
            }
        }

        // --- HÀM 2: XỬ LÝ HỦY LỊCH THÁNG ---
        private async Task HandleMonthlySuccessfulCancellation(int monthlyBookingId, List<int> childBookingIdsToCancel, string accessToken)
        {
            var cancelledChildBookings = new List<BookingReadDto>();

            // Hủy từng con
            foreach (var childId in childBookingIdsToCancel)
            {
                var booking = (await _bookingService.GetBookingAsync(accessToken, $"?$filter=Id eq {childId}")).Data.FirstOrDefault();
                if (booking == null) continue;
                cancelledChildBookings.Add(booking);
                var childUpdateDto = new BookingUpdateDto { Status = "cancelled", UserId = booking.UserId, StadiumId = booking.StadiumId, Date = booking.Date, TotalPrice = booking.TotalPrice, OriginalPrice = booking.OriginalPrice, Note = booking.Note, DiscountId = booking.DiscountId };
                await _bookingService.UpdateBookingAsync(childId, childUpdateDto, accessToken);
            }

            // Cập nhật Monthly mẹ (Logic tính toán status/price giữ nguyên)
            var monthlyBooking = (await _bookingService.GetMonthlyBookingAsync(accessToken, $"?$filter=Id eq {monthlyBookingId}")).Data.FirstOrDefault();
            if (monthlyBooking == null) throw new Exception("Không tìm thấy lịch đặt tháng.");

            var allChildBookingsAfterUpdate = (await _bookingService.GetBookingAsync(accessToken, $"?$filter=MonthlyBookingId eq {monthlyBookingId}")).Data;
            var newTotalPrice = allChildBookingsAfterUpdate.Where(b => !b.Status.Equals("cancelled", StringComparison.OrdinalIgnoreCase)).Sum(b => b.TotalPrice.GetValueOrDefault());
            var remainingActiveBookings = allChildBookingsAfterUpdate.Any(b => !b.Status.Equals("completed", StringComparison.OrdinalIgnoreCase) && !b.Status.Equals("cancelled", StringComparison.OrdinalIgnoreCase));
            var newMonthlyStatus = remainingActiveBookings ? "accepted" : "cancelled";

            var updateDto = new MonthlyBookingUpdateDto { Status = newMonthlyStatus, TotalPrice = newTotalPrice, PaymentMethod = monthlyBooking.PaymentMethod, OriginalPrice = monthlyBooking.OriginalPrice, Note = monthlyBooking.Note, };
            await _bookingService.UpdateMonthlyBookingAsync(monthlyBookingId, updateDto, accessToken);

            // Gửi thông báo & Email
            if (cancelledChildBookings.Any())
            {
                var stadium = await _stadiumService.GetStadiumByIdAsync(monthlyBooking.StadiumId);
                var stadiumName = stadium?.Name ?? "sân";
                bool isFullCancellation = !remainingActiveBookings;
                string notifType, notifTitle, notifMessage;
                string emailSubject, emailBody;

                if (isFullCancellation)
                {
                    notifType = "MonthlyBooking.Cancel";
                    notifTitle = "Gói đặt sân đã bị hủy";
                    notifMessage = $"Chủ sân đã hủy toàn bộ gói đặt sân tháng của bạn tại sân '{stadiumName}'.";
                    emailSubject = $"[Sportivey] Hủy gói đặt sân tháng #{monthlyBookingId}";
                    emailBody = $"<p>Gói đặt sân tháng của bạn tại <strong>{stadiumName}</strong> đã bị hủy toàn bộ.</p>";
                }
                else
                {
                    notifType = "Booking.Cancel";
                    notifTitle = "Một vài lịch đặt đã bị hủy";
                    var cancelledDates = string.Join(", ", cancelledChildBookings.Select(b => b.Date.ToString("dd/MM")));
                    notifMessage = $"Chủ sân đã hủy các lịch đặt ngày: {cancelledDates} trong gói đặt sân tại '{stadiumName}'.";
                    emailSubject = $"[Sportivey] Thay đổi lịch đặt sân tháng #{monthlyBookingId}";
                    emailBody = $"<p>Các ngày sau trong gói tháng tại <strong>{stadiumName}</strong> đã bị hủy: {cancelledDates}</p>";
                }

                // Notification
                var notificationDto = new CreateNotificationDto { UserId = monthlyBooking.UserId, Type = notifType, Title = notifTitle, Message = notifMessage, Parameters = JsonSerializer.Serialize(new { bookingType = "monthly", monthlyBookingId }) };
                await _notificationService.SendNotificationToUserAsync(notificationDto);

                // ✅ GỬI EMAIL (CẬP NHẬT)
                var user = await _userService.GetOtherUserByIdAsync(monthlyBooking.UserId);

                if (user != null && !string.IsNullOrEmpty(user.Email))
                {
                    string finalEmailBody = $@"
                <p>Xin chào <strong>{user.FullName}</strong>,</p>
                {emailBody}
                <p>Vui lòng kiểm tra ứng dụng để biết thêm chi tiết.</p>
            ";

                    string actionLink = "https://localhost:7128/Booking/BookingHistory";
                    await _emailService.SendEmailAsync(user.Email, emailSubject, finalEmailBody, actionLink, "Xem Chi Tiết");
                }
            }
        }
    }
}