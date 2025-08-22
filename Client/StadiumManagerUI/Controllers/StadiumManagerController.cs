using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Threading.Tasks;

namespace StadiumManagerUI.Controllers
{
    public class StadiumManagerController : Controller
    {

        private readonly IStadiumService _service;

        public StadiumManagerController(IStadiumService service)
        {
            _service = service;
        }
        public IActionResult Stadium()
        {
            return View();
        }

        public async Task<IActionResult> GetAllAndSearch(string url)
        {
            var stadium = await _service.SearchStadiumAsync(url);
            return Content(stadium, "application/json");
        }
    }
}
