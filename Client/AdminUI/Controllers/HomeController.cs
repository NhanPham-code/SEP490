using AdminUI.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Diagnostics;

namespace AdminUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDashboardService _dashboardService;

        public HomeController(ILogger<HomeController> logger, IDashboardService dashboardService)
        {
            _logger = logger;
            _dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if(userId == null || userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboardData()
        {
            try
            {
                var dashboardJsonData = await _dashboardService.GetAdminDashboardDataAsync();
                return Content(dashboardJsonData, "application/json");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch admin dashboard data.");
                return StatusCode(500, new { message = "An error occurred while fetching dashboard data." });
            }
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
    }
}
