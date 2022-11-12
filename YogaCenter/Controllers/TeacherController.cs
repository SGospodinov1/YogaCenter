using Microsoft.AspNetCore.Mvc;

namespace YogaCenter.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
