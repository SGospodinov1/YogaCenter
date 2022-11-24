using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YogaCenter.Core.Models;
using YogaCenter.Core.Services;
using YogaCenter.Extensions;

namespace YogaCenter.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            if (User.IsInRole("Administrator"))
            {
                return RedirectToAction("IsTeacher", "Teacher", new { area = "Administration" });
            }

            if (User.IsInRole("Admin"))
            {

                return RedirectToAction("Index", "Home", new { area = "Administration" });
            }


            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            
            return View(new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}