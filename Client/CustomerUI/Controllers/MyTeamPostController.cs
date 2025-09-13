using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace CustomerUI.Controllers
{
    public class MyPostController : Controller
    {
        public IActionResult TeamPostManage()
        {
            return View();
        }
    }
}
