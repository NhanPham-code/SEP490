using Microsoft.AspNetCore.Mvc;

namespace StadiumManagerUI.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult BookingManager()
        {
            return View();
        }
    }
}
