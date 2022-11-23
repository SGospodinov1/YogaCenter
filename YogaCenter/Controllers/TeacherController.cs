using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YogaCenter.Core.Contracts;

namespace YogaCenter.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly ITeacherService service;

        public TeacherController(ITeacherService _service)
        {
            service = _service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AllTeachers()
        {
            var model = await service.GetAllTeachers();

            return View(model);
        }
    }
}
