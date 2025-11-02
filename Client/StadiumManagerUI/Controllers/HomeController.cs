using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Services;
using StadiumManagerUI.Models;
using System.Diagnostics;

namespace StadiumManagerUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStadiumService _stadiumService;
        private readonly IDashboardService _dashboardService;
        private readonly ITokenService _tokenService;

        public HomeController(ILogger<HomeController> logger, IStadiumService stadiumService, IDashboardService dashboardService, ITokenService tokenService)
        {
            _logger = logger;
            _stadiumService = stadiumService;
            _dashboardService = dashboardService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            // Kiểm tra session hoặc cookie để đảm bảo người dùng đã đăng nhập
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null || userId == 0)
            {
                return RedirectToAction("Login", "Common");
            }

            // Chỉ đơn giản trả về View, không cần truyền dữ liệu gì cả
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Stadiums(string searchTerm)
        {
            var stadium = await _stadiumService.SearchStadiumAsync(searchTerm);

            return Content(stadium, "application/json");
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboardData()
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { message = "Access token is missing." });
            }

            try
            {
                var dashboardJsonData = await _dashboardService.GetStadiumManagerDashboardDataAsync(accessToken);
                // Trả về dữ liệu JSON thuần túy
                return Content(dashboardJsonData, "application/json");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Failed to load dashboard data due to a network error.");
                return StatusCode(502, new { message = "Error connecting to backend services." }); // Bad Gateway
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while loading dashboard data.");
                return StatusCode(500, new { message = "An internal server error occurred." });
            }
        }

    }
}
