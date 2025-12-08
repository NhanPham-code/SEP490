using DTOs.BookingDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Diagnostics;
using System.Text.Json;
using DTOs.BookingDTO.ViewModel;
using DTOs.StadiumDTO;
using StadiumManagerUI.Helpers;

namespace StadiumManagerUI.Controllers
{
    public class RevenueController : Controller
    {
        private readonly ILogger<RevenueController> _logger;
        private readonly ITokenService _tokenService;
        private readonly IBookingService _bookingService;
        private readonly IStadiumService _stadiumService;

        public RevenueController(ILogger<RevenueController> logger, ITokenService tokenService, IBookingService bookingService,  IStadiumService stadiumService)
        {
            _logger = logger;
            _tokenService = tokenService;
            _bookingService = bookingService;
            _stadiumService = stadiumService;
        }

        public async Task<IActionResult> Revenue()
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
                return RedirectToAction("Login", "Account");

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            string stadiumFilter = $"&$filter=CreatedBy eq {userId}";
            var stadiumsJson = await _stadiumService.SearchStadiumAsync(stadiumFilter);
            var stadiums = new List<ReadStadiumDTO>();

            if (!string.IsNullOrEmpty(stadiumsJson))
            {
                try
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    options.Converters.Add(new Iso8601TimeSpanConverter());
                    using (JsonDocument doc = JsonDocument.Parse(stadiumsJson))
                    {
                        if (doc.RootElement.TryGetProperty("value", out JsonElement valueElement))
                        {
                            stadiums = JsonSerializer.Deserialize<List<ReadStadiumDTO>>(valueElement.GetRawText(),
                                options) ?? new List<ReadStadiumDTO>();
                        }
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error parsing stadiums JSON: {ex.Message}");
                }
            }

            ViewBag.Stadiums = stadiums;

            try
            {
                var today = DateTime.UtcNow;

                var stadiumIds = stadiums.Any() 
                    ? stadiums.Select(s => s.Id).ToArray() 
                    : new int[] { -1 };

                var initialStats = await _bookingService.GetRevenueStatisticsAsync(
                    accessToken, 
                    today.Year, 
                    today.Month, 
                    today.Day, 
                    stadiumIds 
                );

                return View(initialStats);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting initial revenue statistics.");
                TempData["ErrorMessage"] = "Không thể tải dữ liệu thống kê ban đầu.";
                return View(new RevenueStatisticViewModel());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStatistics(int year, int? month, int? day, [FromQuery] int[]? stadiumIds)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Json(new { success = false, message = "Phiên đăng nhập đã hết hạn." });
            }
            
            if (stadiumIds == null || stadiumIds.Length == 0)
            {
                // Gán mảng mới chứa phần tử -1 (hoặc 0 tùy bạn chọn)
                stadiumIds = new int[] { -1 }; 
            }
            
            try
            {
                var statistics = await _bookingService.GetRevenueStatisticsAsync(accessToken, year, month, day, stadiumIds);
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