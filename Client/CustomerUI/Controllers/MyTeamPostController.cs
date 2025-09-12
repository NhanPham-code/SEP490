using Microsoft.AspNetCore.Mvc;

namespace CustomerUI.Controllers
{
    public class MyPostController : Controller
    {
        public IActionResult MyPosts()
        {
            return View();
        }
    }
}
