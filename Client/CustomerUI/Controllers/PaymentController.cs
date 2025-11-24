using DTOs.BookingDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Text.Json;
using DTOs.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using DTOs.DiscountDTO;
using System.Linq;
using DTOs.NotificationDTO; // Thêm using cho Notification DTO

namespace CustomerUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IDiscountService _discountService;
        private readonly IConfiguration _configuration;
        private readonly IStadiumService _stadiumService;
        private readonly INotificationService _notificationService;

        public PaymentController(
            IBookingService bookingService,
            IDiscountService discountService,
            IConfiguration configuration,
            IStadiumService stadiumService,
            INotificationService notificationService)
        {
            _bookingService = bookingService;
            _discountService = discountService;
            _configuration = configuration;
            _stadiumService = stadiumService;
            _notificationService = notificationService;
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

            string queryString = $"?$filter=Id eq {bookingId}";
            var bookings = (await _bookingService.GetBookingAsync(accessToken, queryString)).Data;
            var booking = bookings.FirstOrDefault();

            if (booking == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy đơn đặt sân.";
                return RedirectToAction("BookingHistory", "Booking");
            }

            string finalStatus;

            if (isPaymentSuccess)
            {
                finalStatus = "accepted";

                // Logic vô hiệu hóa discount... (giữ nguyên)
                if (booking.DiscountId.HasValue && booking.DiscountId > 0)
                {
                    try
                    {
                        var discountDetails = await _discountService.GetDiscountByIdAsync(booking.DiscountId.Value);
                        if (discountDetails != null && "Unique".Equals(discountDetails.CodeType, StringComparison.OrdinalIgnoreCase))
                        {
                            var discountUpdateDto = new UpdateDiscountDTO
                            {
                                Id = discountDetails.Id,
                                Code = discountDetails.Code,
                                Description = discountDetails.Description,
                                PercentValue = discountDetails.PercentValue,
                                MaxDiscountAmount = discountDetails.MaxDiscountAmount,
                                MinOrderAmount = discountDetails.MinOrderAmount,
                                StartDate = discountDetails.StartDate,
                                EndDate = discountDetails.EndDate,
                                CodeType = discountDetails.CodeType,
                                IsActive = false,
                                TargetUserId = discountDetails.TargetUserId,
                                StadiumIds = discountDetails.StadiumIds
                            };
                            await _discountService.UpdateDiscountAsync(accessToken, discountUpdateDto);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[PaymentCallback] Lỗi khi vô hiệu hóa mã Unique Discount ID {booking.DiscountId}: {ex.Message}");
                    }
                }
            }
            else
            {
                finalStatus = "payfail";
            }

            var updateDto = new BookingUpdateDto
            {
                UserId = booking.UserId,
                StadiumId = booking.StadiumId,
                Status = finalStatus,
                Date = booking.Date,
                TotalPrice = booking.TotalPrice,
                OriginalPrice = booking.OriginalPrice,
                Note = booking.Note,
                DiscountId = booking.DiscountId
            };

            try
            {
                await _bookingService.UpdateBookingAsync(bookingId.Value, updateDto, accessToken);

                if (finalStatus == "accepted")
                {
                    TempData["BookingSuccess"] = true;
                    TempData["SuccessMessage"] = "Đặt sân và thanh toán thành công!";

                    // Gửi thông báo cho chủ sân (BOOKING NGÀY)
                    await SendNewBookingNotificationAsync("daily", bookingId.Value, booking.StadiumId);
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
                HttpContext.Session.Remove("AccessToken");
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
            bool isPaymentSuccess = vnpay.ValidateSignature(hashSecret) && vnp_ResponseCode == "00";

            int? monthlyBookingId = HttpContext.Session.GetInt32("MonthlyBookingId");
            var accessToken = HttpContext.Session.GetString("AccessToken");

            if (monthlyBookingId == null || string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Không xác định được booking hàng tháng để cập nhật.";
                return RedirectToAction("BookingHistory", "Booking");
            }

            string queryString = $"?$filter=Id eq {monthlyBookingId}";
            var monthlyBookings = (await _bookingService.GetMonthlyBookingAsync(accessToken, queryString)).Data;
            var monthlyBooking = monthlyBookings.FirstOrDefault();

            if (monthlyBooking == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy booking hàng tháng.";
                return RedirectToAction("BookingHistory", "Booking");
            }

            var updateDto = new MonthlyBookingUpdateDto
            {
                Status = isPaymentSuccess ? "accepted" : "canceled",
                TotalPrice = monthlyBooking.TotalPrice,
                PaymentMethod = monthlyBooking.PaymentMethod,
                OriginalPrice = monthlyBooking.OriginalPrice,
                Note = monthlyBooking.Note,
            };

            try
            {
                await _bookingService.UpdateMonthlyBookingAsync(monthlyBookingId.Value, updateDto, accessToken);

                if (isPaymentSuccess)
                {
                    // Logic vô hiệu hóa discount... (giữ nguyên)
                    if (monthlyBooking.DiscountId.HasValue && monthlyBooking.DiscountId > 0)
                    {
                        try
                        {
                            var discountDetails = await _discountService.GetDiscountByIdAsync(monthlyBooking.DiscountId.Value);
                            if (discountDetails != null && "Unique".Equals(discountDetails.CodeType, StringComparison.OrdinalIgnoreCase))
                            {
                                var discountUpdateDto = new UpdateDiscountDTO
                                {
                                    Id = discountDetails.Id,
                                    Code = discountDetails.Code,
                                    Description = discountDetails.Description,
                                    PercentValue = discountDetails.PercentValue,
                                    MaxDiscountAmount = discountDetails.MaxDiscountAmount,
                                    MinOrderAmount = discountDetails.MinOrderAmount,
                                    StartDate = discountDetails.StartDate,
                                    EndDate = discountDetails.EndDate,
                                    CodeType = discountDetails.CodeType,
                                    IsActive = false,
                                    TargetUserId = discountDetails.TargetUserId,
                                    StadiumIds = discountDetails.StadiumIds
                                };
                                await _discountService.UpdateDiscountAsync(accessToken, discountUpdateDto);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[MonthlyPaymentCallback] Lỗi khi vô hiệu hóa mã Unique Discount ID {monthlyBooking.DiscountId}: {ex.Message}");
                        }
                    }

                    // Cập nhật trạng thái cho tất cả booking con
                    var childBookings = (await _bookingService.GetBookingAsync(accessToken, $"?$filter=MonthlyBookingId eq {monthlyBookingId}")).Data;
                    foreach (var child in childBookings)
                    {
                        var childUpdateDto = new BookingUpdateDto
                        {
                            Status = "accepted",
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
                    TempData["SuccessMessage"] = "Đặt sân hàng tháng và thanh toán thành công!";

                    // *** THAY ĐỔI: GỬI MỘT THÔNG BÁO DUY NHẤT CHO GÓI THÁNG ***
                    // Lời gọi hàm được đưa ra ngoài vòng lặp và sử dụng ID của gói tháng.
                    await SendNewBookingNotificationAsync("monthly", monthlyBookingId.Value, monthlyBooking.StadiumId);
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

        /// <summary>
        /// Tạo và gửi thông báo có lịch đặt sân mới cho chủ sân.
        /// </summary>
        /// <param name="bookingType">Loại booking: "daily" hoặc "monthly".</param>
        /// <param name="bookingId">ID của booking (booking con nếu là daily, booking cha nếu là monthly).</param>
        /// <param name="stadiumId">ID của sân vận động được đặt.</param>
        private async Task SendNewBookingNotificationAsync(string bookingType, int bookingId, int stadiumId)
        {
            try
            {
                var stadium = await _stadiumService.GetStadiumByIdAsync(stadiumId);

                if (stadium != null && stadium.CreatedBy > 0)
                {
                    int ownerId = stadium.CreatedBy;

                    // *** THAY ĐỔI: Tùy chỉnh nội dung và loại thông báo dựa trên bookingType ***
                    string notifType;
                    string notifTitle;
                    string notifMessage;
                    object notifParams;

                    if (bookingType == "monthly")
                    {
                        notifType = "MonthlyBooking.New";
                        notifTitle = "Gói đặt sân tháng mới";
                        notifMessage = $"Sân '{stadium.Name}' của bạn vừa có một gói đặt sân theo tháng được thanh toán thành công.";
                        notifParams = new { bookingType, monthlyBookingId = bookingId }; // Tham số trỏ đến ID của gói tháng
                    }
                    else // Mặc định là "daily"
                    {
                        notifType = "Booking.New";
                        notifTitle = "Lịch đặt sân mới";
                        notifMessage = $"Sân '{stadium.Name}' của bạn vừa có một lịch đặt mới đã thanh toán thành công.";
                        notifParams = new { bookingType, bookingId };
                    }

                    var notificationDto = new CreateNotificationDto
                    {
                        UserId = ownerId,
                        Type = notifType,
                        Title = notifTitle,
                        Message = notifMessage,
                        Parameters = JsonSerializer.Serialize(notifParams),
                    };

                    await _notificationService.SendNotificationToUserAsync(notificationDto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[NotificationError] Lỗi khi gửi thông báo cho {bookingType} booking ID {bookingId}: {ex.Message}");
            }
        }
    }
}