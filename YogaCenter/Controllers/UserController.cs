using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YogaCenter.Core.Models;
using YogaCenter.Infrastructure.Data.DataModels;
using YogaCenter.Models;
using YogaCenter.Models.Account;

namespace Library.Controllers
{
    public class UserController : Controller
    {
       private readonly UserManager<AppUser> userManager;
       private readonly SignInManager<AppUser> signInManager;
       private readonly RoleManager<IdentityRole> roleManager;



       public UserController(UserManager<AppUser> _userManager,
            SignInManager<AppUser> _signInManager,
            RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
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

           var user = new AppUser()
           {
               FirstName = model.FirstName,
               LastName = model.LastName,
               UserName = model.UserName,
               Email = model.Email
           };

           var result = await userManager.CreateAsync(user, model.Password);

           if (result.Succeeded)
           {
                if (user.Email == "admin@admin.com")
                {
                    if (!(await roleManager.RoleExistsAsync("Admin")))
                    {
                        await roleManager.CreateAsync(new IdentityRole("Admin"));
                    }

                    await userManager.AddToRoleAsync(user, "Admin");
                    //    await userManager.AddToRoleAsync(user, "Admin");
                }

                return RedirectToAction("Login", "User");
           }

           foreach (var item in result.Errors)
           {
               ModelState.AddModelError("", item.Description);
           }

           return RedirectToAction("Login", "User");
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

           
           return RedirectToAction("Error", "Home");
       }

        [HttpPost]
       public async Task<IActionResult> Logout()
       {
           await signInManager.SignOutAsync();

           return RedirectToAction("Index", "Home");
       }


    //   public async Task<IActionResult> AddUserToRole()
    //   {
    //       var roleName = "Admin";
    //       var roleExists = await roleManager.RoleExistsAsync(roleName);

    //       if (roleExists)
    //       {
    //           var user = await userManager.GetUserAsync(User);
    //           var result = await userManager.AddToRoleAsync(user, roleName);

    //           if (result.Succeeded)
    //           {
    //               return RedirectToAction("AdminIndex", "AdminHome");
    //           }
    //       }
    //   }
    }
}
