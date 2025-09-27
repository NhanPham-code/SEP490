using Microsoft.AspNetCore.Mvc;

namespace AdminUI.Controllers
{
    public class ChatController : Controller
    {
        [HttpGet]
        public IActionResult Chat()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var fullName = HttpContext.Session.GetString("FullName");

            if (userId == null || userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.UserId = userId;
            ViewBag.UserName = string.IsNullOrEmpty(fullName) ? "Admin" : fullName;

            return View();
        }
    }
}
