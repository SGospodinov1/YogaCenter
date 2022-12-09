using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models.Admin;
using YogaCenter.Infrastructure.Data.Common;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository repo;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminService(IRepository _repo,
            UserManager<AppUser> _userManager,
            RoleManager<IdentityRole> _roleManager)
        {
            repo = _repo;
            userManager = _userManager;
            roleManager = _roleManager;
        }

        public async Task<IEnumerable<UserViewModel>> AllUsers()
        {
            
            var users = await repo.AllReadonly<AppUser>()
                .Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email

                })
                .ToListAsync();

            foreach (var user in users)
            {
                var userInRole = await repo.GetByIdAsync<AppUser>(user.Id);

                if (await userManager.IsInRoleAsync(userInRole, "Administrator"))
                {
                    user.IsAdministrator = true;
                }
                else
                {
                    user.IsAdministrator = false;

                }
            }
            
            return users;
        }

        
        public async Task Add(string id)
        {
            var roleName = "Administrator";

            if (!(await roleManager.RoleExistsAsync(roleName)))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            var user = await repo.GetByIdAsync<AppUser>(id);

            if (!await userManager.IsInRoleAsync(user, roleName))
            {
                await userManager.AddToRoleAsync(user, roleName);
            }

        }

        public async Task Remove(string id)
        {
            var roleName = "Administrator";

            var user = await repo.GetByIdAsync<AppUser>(id);

            if (await userManager.IsInRoleAsync(user, roleName))
            {
                await userManager.RemoveFromRoleAsync(user, roleName);
            }
        }

        public async Task RemoveTeacher(string id)
        {
            var user = await repo.AllReadonly<Teacher>()
                .FirstOrDefaultAsync(t => t.AppUserId == id);

            var teacher = await repo.GetByIdAsync<Teacher>(user.Id);

            teacher.IsDeleted = true;

            await repo.SaveChangesAsync();
        }
    }
}
