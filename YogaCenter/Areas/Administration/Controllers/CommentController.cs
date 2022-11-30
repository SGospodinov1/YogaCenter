using Microsoft.AspNetCore.Mvc;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models;
using YogaCenter.Extensions;

namespace YogaCenter.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[controller]/[action]")]
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

            var model = await service.GetAll(classId);


            return View(model);
        }

    }
}
