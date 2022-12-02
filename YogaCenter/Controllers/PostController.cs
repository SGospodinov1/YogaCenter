using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YogaCenter.Core.Contracts;

namespace YogaCenter.Controllers
{
    
    public class PostController : Controller
    {
        private readonly IPostService service;

        public PostController(IPostService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> AllPosts()
        {
            var model = await service.AllPosts();

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


    }
}
