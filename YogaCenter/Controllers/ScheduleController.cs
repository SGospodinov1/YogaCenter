using Microsoft.AspNetCore.Mvc;

namespace YogaCenter.Controllers
{
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
