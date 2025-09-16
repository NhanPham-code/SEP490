using Microsoft.AspNetCore.Mvc;

namespace CustomerUI.Controllers
{
    public class TeamMemberController : Controller
    {
        public IActionResult TeamManage()
        {
            return View();
        }
    }
}
