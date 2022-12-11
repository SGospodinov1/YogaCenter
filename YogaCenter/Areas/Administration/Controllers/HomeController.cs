using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using YogaCenter.Core.Models;
using YogaCenter.Core.Services;
using YogaCenter.Extensions;
using YogaCenter.Models;

namespace YogaCenter.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[controller]/[action]")]
    public class HomeController : Controller
    {
        

        public async Task<IActionResult> Index()
        {
            
            return View();
        }



        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}