using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models.Administrator;
using YogaCenter.Extensions;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[controller]/[action]")]
    [Authorize]
    public class YogaClassController : Controller
    {
        private readonly IYogaClassService service;
        private readonly ITeacherService teacherService;

        public YogaClassController(IYogaClassService _service, ITeacherService _teacherService)
        {
            service = _service;
            teacherService = _teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> AllClasses()
        {
            var model = await service.GetAll();

            return View(model);
        }

        public async Task<IActionResult> MyClasses()
        {

            string userId = User.Id();
            TempData["userId"] = userId;
            var model = await service.TeacherClasses(userId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateYogaClass(string userId)
        {
            var model = new CreateYogaClassViewModel()
            {
                TeacherId = await teacherService.FindTeacherId(userId),
                Categories = await service.GetAllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateYogaClass(CreateYogaClassViewModel model)
        {
            if (service.IsDateAndTimeAreValid(model) == false)
            {
                ModelState.AddModelError(string.Empty, "Date or Time is invalid.");
            }

            if (await service.IsThereOtherClassInTheSameTime(model) == true)
            {
                ModelState.AddModelError(string.Empty, "There is other class during this time interval.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await service.GetAllCategoriesAsync();

                return View(model);
            }

            await service.AddYogaClass(model);


            return RedirectToAction("MyClasses", "YogaClass");
        }

        [HttpGet]
        public async Task<IActionResult> EditYogaClass(int classId)
        {
            var model = await service.GetYogaClassForEdit(classId);

            model.Categories = await service.GetAllCategoriesAsync();

            return View(model);
        }
            
        [HttpPost]
        public async Task<IActionResult> EditYogaClass(CreateYogaClassViewModel model)
        {
            if (service.IsDateAndTimeAreValid(model) == false)
            {
                ModelState.AddModelError(string.Empty, "Date or Time is invalid.");
            }

            if (await service.IsThereOtherClassInTheSameTime(model) == true)
            {
                ModelState.AddModelError(string.Empty, "There is other class during this time interval.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await service.GetAllCategoriesAsync();
                return View(model);
            }

            await service.EditClass(model);

            return RedirectToAction("MyClasses", "YogaClass");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteYogaClass(int classId)
        {
            await service.DeleteClass(classId);

            return RedirectToAction("MyClasses", "YogaClass");
        }
    }
}
