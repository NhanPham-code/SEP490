using Microsoft.AspNetCore.Mvc;

namespace StadiumManagerUI.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inventory()
        {
            return View();
        }

        public IActionResult StadiumInventory()
        {
            return View();
        }
    }
}