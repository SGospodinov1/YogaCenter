using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YogaCenter.Core.Contracts;

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
    }
}
