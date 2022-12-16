using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models.Admin;

namespace YogaCenter.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[controller]/[action]")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAdminService service;

        public AdminController(IAdminService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> AddUserToRole()
        {
            var model = await service.AllUsers();

            return View(model);
        }

        

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(string userId)
        {
            await service.Add(userId);

            return RedirectToAction("AddUserToRole", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUserFromRole(string userId)
        {
            await service.Remove(userId);

            await service.RemoveTeacher(userId);

            return RedirectToAction("AddUserToRole", "Admin");
        }
    }
}
