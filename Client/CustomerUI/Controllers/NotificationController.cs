using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace CustomerUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly ITokenService _tokenService;

        public NotificationController(INotificationService notificationService, ITokenService tokenService)
        {
            _notificationService = notificationService;
            _tokenService = tokenService;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Common");
            }
            return View();
        }

        public async Task<IActionResult> GetMyNotifications(int top, int skip)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return Unauthorized();
            }
            try
            {
                var notifications = await _notificationService.GetNotificationsByUserIdAsync(userId.Value, top, skip);
                return Json(notifications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error fetching notifications: " + ex.Message);
            }
        }

        public async Task<IActionResult> GetUnreadNotificationCount()
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized();
            }

            try
            {
                var count = await _notificationService.GetUnreadNotificationCountAsync(accessToken);
                return Json(count);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error fetching unread notification count: " + ex.Message);
            }
        }

        public async Task<IActionResult> MarkAllAsRead()
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized();
            }

            try
            {
                await _notificationService.MarkAllAsReadAsync(accessToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error marking notifications as read: " + ex.Message);
            }
        }
    }
}
