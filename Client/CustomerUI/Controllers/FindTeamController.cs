using Microsoft.AspNetCore.Mvc;

namespace CustomerUI.Controllers
{
    public class FindTeamController : Controller
    {
        public IActionResult FindTeam()
        {
            return View();
        }
    }
}
