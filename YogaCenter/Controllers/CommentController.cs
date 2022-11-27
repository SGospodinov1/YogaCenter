using Microsoft.AspNetCore.Mvc;
using YogaCenter.Core.Contracts;

namespace YogaCenter.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService service;

        public CommentController(ICommentService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> AllComments()
        {
            return View();
        }


    }
}
