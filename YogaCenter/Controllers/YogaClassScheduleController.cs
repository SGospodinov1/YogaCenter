using Microsoft.AspNetCore.Mvc;

namespace YogaCenter.Controllers
{
    public class YogaClassScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
