using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YogaCenter.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
