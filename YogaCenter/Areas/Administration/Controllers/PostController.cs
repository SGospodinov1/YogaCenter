using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YogaCenter.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
