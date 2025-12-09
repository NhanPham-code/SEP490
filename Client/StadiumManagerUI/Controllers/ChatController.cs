using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Threading.Tasks;

namespace CustomerUI.Controllers
{
    public class ChatController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;


        public ChatController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }
        private string? GetAccessToken()
        {
            return Request.Cookies["AccessToken"];
        }

        private string? GetRefreshToken()
        {
            return Request.Cookies["RefreshToken"];
        }

        public async Task<IActionResult> Chat()
        {
            var accessToken = GetAccessToken();

            if (string.IsNullOrEmpty(accessToken))
            {
                return RedirectToAction("Login", "Common");
            }

            var profile = await _userService.GetMyProfileAsync(accessToken);

            ViewBag.UserId = profile?.UserId;
            ViewBag.UserName = profile?.FullName ?? "User";
            ViewBag.Profile = profile;
            ViewBag.CloudinaryCloudName = "dwt7k4avh";
            ViewBag.CloudinaryPreset = "ChatMoBe";

            return View();
        }
    }
}