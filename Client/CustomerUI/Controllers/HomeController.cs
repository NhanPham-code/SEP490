using CustomerUI.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CustomerUI.Controllers
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

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Stadiums()
        {
            var stadium = await _stadiumService.GetAllStadiumsAsync();

            return Content(stadium, "application/json");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Map()
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
