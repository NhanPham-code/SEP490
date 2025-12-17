using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using DTOs.UserDTO;
using System.Threading.Tasks;

namespace CustomerUI.Controllers
{
    public class ChatController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private static readonly string BASE_URL = "https://localhost:7136";

        public ChatController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        private string? GetAccessToken()
        {
            return Request.Cookies["AccessToken"];
        }

        /// <summary>
        /// Trang chính của Chat
        /// </summary>
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

        /// <summary>
        /// Partial View cho User Hidden Fields
        /// </summary>
        public async Task<PartialViewResult> UserHiddenFields()
        {
            var accessToken = GetAccessToken();
            var profile = await _userService.GetMyProfileAsync(accessToken);

            ViewBag.UserId = profile?.UserId;
            ViewBag.UserName = profile?.FullName ?? "User";

            return PartialView("_UserHiddenFields");
        }

        /// <summary>
        /// ✅ API:  Lấy danh sách Users để hiển thị trong Contacts
        /// COPY 100% LOGIC TỪ AdminUI AccountController. GetUsers()
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetContacts([FromQuery] UserSearchRequestDTO request)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Json(new { success = false, message = "Unauthorized" });
            }

            try
            {
                // ✅ GIỐNG ADMIN:  Gọi GetUsersForAdmin
                var usersResponse = await _userService.GetUsersForAdmin(accessToken, request);

                var totalRecords = usersResponse.Count ?? 0;
                var totalPages = (int)Math.Ceiling((double)totalRecords / request.PageSize);

                // ✅ GIỐNG ADMIN: Format avatar URL
                usersResponse.Value.ForEach(user =>
                {
                    user.AvatarUrl = !string.IsNullOrEmpty(user.AvatarUrl)
                        ? $"{BASE_URL}{user.AvatarUrl}"
                        : $"{BASE_URL}/avatars/default-avatar.png";

                    user.FrontCCCDUrl = !string.IsNullOrEmpty(user.FrontCCCDUrl)
                        ? $"{BASE_URL}{user.FrontCCCDUrl}"
                        : null;
                });

                // ✅ GIỐNG ADMIN: Trả về JSON với success, data, totalRecords, totalPages
                return Json(new
                {
                    success = true,
                    data = usersResponse.Value,
                    totalRecords = totalRecords,
                    totalPages = totalPages
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error fetching users: " + ex.Message });
            }
        }
    }
}