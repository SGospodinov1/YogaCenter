using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YogaCenter.Core.Models;

namespace YogaCenter.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Administrator"))
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