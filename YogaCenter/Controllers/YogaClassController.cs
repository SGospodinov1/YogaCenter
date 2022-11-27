using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YogaCenter.Core.Contracts;
using YogaCenter.Extensions;

namespace YogaCenter.Controllers
{
    [Authorize]
    public class YogaClassController : Controller
    {
        private readonly IYogaClassService service;

        public YogaClassController(IYogaClassService _service)
        {
            service = _service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AllClasses()
        {
            var model = await service.GetAll();

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> MyClasses()
        {
            string userId = User.Id();
            var model = await service.GetMyClasses(userId);

            return View(model);
        }

        public async Task<IActionResult> Join(int classId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            string userId = User.Id();

            await service.AddToMyClasses(classId, userId);

            return RedirectToAction("AllClasses", "YogaClass");
        }

        public async Task<IActionResult> Leave(int classId)
        {
            string userId = User.Id();

            await service.RemoveFromMyClasses(classId, userId);

            return RedirectToAction("MyClasses", "YogaClass");
        }

    }
}
