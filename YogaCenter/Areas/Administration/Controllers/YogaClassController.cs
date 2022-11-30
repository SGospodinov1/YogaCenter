using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YogaCenter.Core.Contracts;
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
            var model = await service.GetMyClasses(userId);

            return View(model);
        }

        
    }
}
