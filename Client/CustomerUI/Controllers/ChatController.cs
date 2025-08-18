using Microsoft.AspNetCore.Mvc;

namespace CustomerUI.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Chat()
        {
            // Kiểm tra xem cookie có được lưu chưa
            var hasCookie = Request.Cookies.ContainsKey(".AspNetCore.Session");
            var sessionId = HttpContext.Session.Id;
            var userId = HttpContext.Session.GetString("UserId");
            var fullName = HttpContext.Session.GetString("FullName");

            Console.WriteLine($"Session cookie tồn tại: {hasCookie}");
            Console.WriteLine($"SessionId: {sessionId}, UserId: {userId}");

            // Kiểm tra xem user đã login chưa
            if (string.IsNullOrEmpty(userId))
            {
                // Redirect to login if user is not logged in
                return RedirectToAction("Login", "Common");
            }

            // Pass the actual UserId instead of SessionId
            ViewBag.UserId = userId;
            ViewBag.UserName = fullName ?? "User";
            ViewBag.SessionId = sessionId; // Keep this for debugging if needed

            return View();
        }
    }
}