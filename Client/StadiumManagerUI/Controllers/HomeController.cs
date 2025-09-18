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

        public HomeController(ILogger<HomeController> logger, IStadiumService stadiumService)
        {
            _logger = logger;
            _stadiumService = stadiumService;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null || userId == 0)
            {
                return RedirectToAction("Login", "Common");
            }
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
    }
}
