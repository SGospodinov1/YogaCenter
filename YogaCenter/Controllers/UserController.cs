using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using YogaCenter.Infrastructure.Data.DataModels;
using YogaCenter.Models;
using YogaCenter.Models.Account;

namespace Library.Controllers
{
    public class UserController : Controller
    {
       private readonly UserManager<User> userManager;
       private readonly SignInManager<User> signInManager;

       public UserController(UserManager<User> _userManager,
           SignInManager<User> _signInManager)
       {
           userManager = _userManager;
           signInManager = _signInManager;
       }

        [HttpGet]
       public IActionResult Register()
       {
           var model = new RegisterViewModel();

           return View(model);
       }

        [HttpPost]
       public async Task<IActionResult> Register(RegisterViewModel model)
       {
           if (!ModelState.IsValid)
           {
               return View(model);
           }

           var user = new User()
           {
               UserName = model.UserName,
               Email = model.Email
           };

           var result = await userManager.CreateAsync(user, model.Password);

           if (result.Succeeded)
           {
               return RedirectToAction("Login", "User");
           }

           foreach (var item in result.Errors)
           {
               ModelState.AddModelError("", item.Description);
           }

           return View(model);
       }

        [HttpGet]
       public IActionResult Login()
       {
           var model = new LoginViewModel();

           return View(model);
       }

        [HttpPost]
       public async Task<IActionResult> Login(LoginViewModel model)
       {
           if (!ModelState.IsValid)
           {
               return View(model);
           }

           var user = await userManager.FindByNameAsync(model.UserName);

           if (user != null)
           {
              var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
              return RedirectToAction("Index", "Home");
           }

           var error = new ErrorViewModel()
           {
               RequestId = "Invalid User. Please try again"
           };

           return View(error);
       }

        [HttpPost]
       public async Task<IActionResult> Logout()
       {
           await signInManager.SignOutAsync();

           return RedirectToAction("Index", "Home");
       }

    }
}
