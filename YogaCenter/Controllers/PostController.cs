using Microsoft.AspNetCore.Mvc;

namespace YogaCenter.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
