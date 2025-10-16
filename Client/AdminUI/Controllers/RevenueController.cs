using DTOs.BookingDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Diagnostics;

namespace AdminUI.Controllers
{
    public class RevenueController : Controller
    {
        private readonly ILogger<RevenueController> _logger;
        private readonly ITokenService _tokenService;
        private readonly IBookingService _bookingService;

        public RevenueController(ILogger<RevenueController> logger, ITokenService tokenService, IBookingService bookingService)
        {
            _logger = logger;
            _tokenService = tokenService;
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Revenue()
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Bạn chưa đăng nhập hoặc phiên đã hết hạn.";
                return RedirectToAction("Login", "Account");
            }

            try
            {
                // Lấy dữ liệu thống kê cho ngày hiện tại để hiển thị lần đầu
                var today = DateTime.UtcNow;
                var initialStats = await _bookingService.GetRevenueStatisticsAsync(accessToken, today.Year, today.Month, today.Day, null);

                // Truyền model vào View
                return View(initialStats);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting initial revenue statistics.");
                TempData["ErrorMessage"] = "Không thể tải dữ liệu thống kê ban đầu.";
                // Vẫn trả về View với model rỗng để trang không bị lỗi
                return View(new RevenueStatisticViewModel());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStatistics(int year, int? month, int? day)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Json(new { success = false, message = "Phiên đăng nhập đã hết hạn." });
            }
            try
            {
                var statistics = await _bookingService.GetRevenueStatisticsAsync(accessToken, year, month, day, null);
                return Json(statistics);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting statistics for year={year}, month={month}, day={day}", year, month, day);
                return Json(new { success = false, message = "Có lỗi xảy ra khi lấy dữ liệu." });
            }
        }
        
        [HttpGet]
        public IActionResult StadiumRevenue()
        {
            // Chỉ cần trả về View, dữ liệu sẽ được load bằng AJAX
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetStadiumRevenueData(int page, int pageSize, int? year, int? month, int? day)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Json(new { success = false, message = "Phiên đăng nhập đã hết hạn." });
            }
            try
            {
                var data = await _bookingService.GetStadiumRevenueAsync(accessToken, page, pageSize, year, month, day);
                return Json(new { success = true, data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting stadium revenue data.");
                return Json(new { success = false, message = "Có lỗi xảy ra khi lấy dữ liệu." });
            }
        }
    }
}