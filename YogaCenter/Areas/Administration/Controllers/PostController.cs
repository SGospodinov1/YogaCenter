using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models.Administrator;
using YogaCenter.Extensions;

namespace YogaCenter.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[controller]/[action]")]
    public class PostController : Controller
    {
        
        private readonly IPostService service;
        private readonly ITeacherService teacherService;

        public PostController(IPostService _service, ITeacherService _teacherService)
        {
            service = _service;
            teacherService = _teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> MyPosts()
        {

            string userId = User.Id();
            TempData["userId"] = userId;
            var model = await service.MyPosts(userId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> PostDetails(int postId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var model = await service.FindPost(postId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewPost(string userId)
        {
            var model = new CreateNewPostViewModel()
            {
                TeacherId = await teacherService.FindTeacherId(userId)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPost(CreateNewPostViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            await service.CreatePost(model);

            return RedirectToAction("MyPosts", "Post");
        }

        [HttpGet]
        public async Task<IActionResult> EditPost(int postId)
        {

            var model = await service.GetPostForEdit(postId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(CreateNewPostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service.EditPost(model);

            return RedirectToAction("MyPosts", "Post");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int postId)
        {
            await service.DeletePost(postId);

            return RedirectToAction("MyPosts", "Post");
        }
    }
}
