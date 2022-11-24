using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models.Administrator;
using YogaCenter.Extensions;

namespace YogaCenter.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[controller]/[action]")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService service;

        public TeacherController(ITeacherService _service)
        {
            service = _service;
        }

        [HttpGet]
        public IActionResult NewTeacher()
        {
            var model = new NewTeacherViewModel();

           

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> NewTeacher(NewTeacherViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            await service.AddNewTeacher(model);

            return RedirectToAction("Index", "Home", new { area = "Administration" });
        }

        public async Task<IActionResult> IsTeacher()
        {
            var userId = User.Id();

            bool result = await service.IsTeacher(userId);

            if (result == false)
            {
                return RedirectToAction("NewTeacher", "Teacher", new { area = "Administration" });
            }

            return RedirectToAction("Index", "Home", new { area = "Administration" });
        }

        [HttpGet]
        public async Task<IActionResult> MyInfo()
        {
            string userId = User.Id();

            var model = await service.MyInfo(userId);

            return View(model);
        }

        public async Task<IActionResult> MyClasses()
        {
            return View();
        }
    }
}
