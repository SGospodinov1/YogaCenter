using Microsoft.AspNetCore.Mvc;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models;
using YogaCenter.Extensions;

namespace YogaCenter.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService service;

        public CommentController(ICommentService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> AllComments(int classId)
        {

            ViewBag.YogaClassName = await service.YogaClassName(classId);
            TempData["classId"] = classId;

            var model = await service.GetAll(classId);


            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddComment(int classId)
        {
            string userId = User.Id();

            var model = new CommentViewModel()
            {
                FullName = await service.UserFullName(userId),
                AppUserId = userId,
                YogaClassId = classId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await service.Add(model);

            return RedirectToAction("AllComments", new {classId = model.YogaClassId});
        }
    }
}
