using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YogaCenter.Core.Contracts;

namespace YogaCenter.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class YogaClassScheduleController : Controller
    {
        private readonly IYogaClassScheduleService service;

        public YogaClassScheduleController(IYogaClassScheduleService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> AllClasses()
        {
            var model = await service.GetAll();

            return View(model);
        }
    }
}
