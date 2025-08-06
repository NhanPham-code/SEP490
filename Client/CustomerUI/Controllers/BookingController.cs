using Microsoft.AspNetCore.Mvc;

namespace CustomerUI.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult TimeZone()
        {
            return View();
        }
    }
}
