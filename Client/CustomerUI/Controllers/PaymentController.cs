using DTOs.BookingDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Text.Json;
using DTOs.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using DTOs.DiscountDTO; // Thêm using cho Discount DTOs
using System.Linq; // Thêm using cho LINQ

namespace CustomerUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IDiscountService _discountService; // *** THÊM IDiscountService
        private readonly IConfiguration _configuration;

        public PaymentController(
            IBookingService bookingService,
            IDiscountService discountService, // *** INJECT IDiscountService
            IConfiguration configuration)
        {
            _bookingService = bookingService;
            _discountService = discountService; // *** GÁN SERVICE
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
                finalStatus = "accepted";

                // *** LOGIC VÔ HIỆU HÓA DISCOUNT "UNIQUE" START ***
                if (booking.DiscountId.HasValue && booking.DiscountId > 0)
                {
                    try
                    {
                        var discountDetails = await _discountService.GetDiscountByIdAsync(booking.DiscountId.Value);
                        if (discountDetails != null && "Unique".Equals(discountDetails.CodeType, StringComparison.OrdinalIgnoreCase))
                        {
                            // Tạo DTO để cập nhật
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
                                IsActive = false, // Vô hiệu hóa mã
                                TargetUserId = discountDetails.TargetUserId,
                                StadiumIds = discountDetails.StadiumIds
                            };
                            await _discountService.UpdateDiscountAsync(accessToken, discountUpdateDto);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Ghi log lỗi nhưng không làm gián đoạn luồng chính
                        Console.WriteLine($"[PaymentCallback] Lỗi khi vô hiệu hóa mã Unique Discount ID {booking.DiscountId}: {ex.Message}");
                    }
                }
                // *** LOGIC VÔ HIỆU HÓA DISCOUNT "UNIQUE" END ***
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
            var monthlyBookings = await _bookingService.GetMonthlyBookingAsync(accessToken, queryString);
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
                    // *** LOGIC VÔ HIỆU HÓA DISCOUNT "UNIQUE" START ***
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
                                    IsActive = false, // Vô hiệu hóa mã
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

                    var childBookings = await _bookingService.GetBookingAsync(accessToken, $"?$filter=MonthlyBookingId eq {monthlyBookingId}");
                    foreach (var child in childBookings)
                    {
                        var childUpdateDto = new BookingUpdateDto
                        {
                            Status = "accepted", // Đã thanh toán thành công
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
                // Không xóa AccessToken ở đây để các lệnh gọi API sau đó vẫn hoạt động
            }

            return RedirectToAction("BookingHistory", "Booking");
        }
    }
}