using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace CustomerUI.Controllers
{
    public class StadiumController : Controller
    {
        private readonly IStadiumService _stadiumService;
        private readonly ITokenService _tokenService;

        public StadiumController(IStadiumService stadiumService, ITokenService tokenService)
        {
            _stadiumService = stadiumService;
            _tokenService = tokenService;
        }
   
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> StadiumDetail(int stadiumId)
        {
            if (stadiumId <= 0)
            {
                return RedirectToAction("Index", "Home");
            }

            var stadium = await _stadiumService.GetStadiumByIdAsync(stadiumId);

            if (stadium == null)
            {
                return NotFound();
            }

            return View("StadiumDetail", stadium);
        }
    }
}
