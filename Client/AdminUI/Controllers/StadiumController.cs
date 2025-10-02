using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace AdminUI.Controllers
{
    public class StadiumController : Controller
    {

        private readonly IStadiumService _service;
        private readonly IStadiumImageService _imageService;
        private readonly IStadiumVideoSetvice _videoService;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;


        public StadiumController(IStadiumService stadiumService, IStadiumImageService stadiumImageService, IStadiumVideoSetvice stadiumVideoSetvice, ITokenService tokenService, IUserService userService)
        {
            _service = stadiumService;
            _imageService = stadiumImageService;
            _videoService = stadiumVideoSetvice;
            _tokenService = tokenService;
            _userService = userService;
        }
        public IActionResult StadiumAdmin()
        {
            return View();
        }

        public async Task<IActionResult> GetAllAndSearch(string url)
        {
            var token = _tokenService.GetAccessTokenFromCookie();
            var userId = await _userService.GetMyProfileAsync(token);
            var stadium = await _service.SearchStadiumAsync(url);
            return Content(stadium, "application/json");
        }

        public async Task<IActionResult> LockStadium(int id)
        {

            var locked = await _service.DeleteStadiumAsync(id);

            if (locked)
            {
                return Json(new { success = 200, value = locked });
            }
            else
                return Json(new { success = 400, value = locked });
        }
    }
}
