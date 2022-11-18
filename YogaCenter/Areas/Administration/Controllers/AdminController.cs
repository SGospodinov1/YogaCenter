using Microsoft.AspNetCore.Mvc;
using YogaCenter.Core.Models.Admin;

namespace YogaCenter.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult AddUsersToRoles()
        {
            var model = new AddUserToRoleViewModel();

            return View(model);
        }
    }
}
