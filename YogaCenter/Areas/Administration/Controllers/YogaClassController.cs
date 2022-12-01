﻿using Microsoft.AspNetCore.Authorization;
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

        public YogaClassController(IYogaClassService _service)
        {
            service = _service;
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
                TeacherId = await service.FindTeacherId(userId),
                Categories = await service.GetAllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateYogaClass(CreateYogaClassViewModel model)
        {
            if (!ModelState.IsValid)
            {
                
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
        public async Task<IActionResult> EditYogaClass(EditYogaClassViewModel model)
        {
            if (ModelState.IsValid == false)
            {
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
