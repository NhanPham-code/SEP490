using Microsoft.AspNetCore.Mvc;

namespace CustomerUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
