using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models.Admin;
using YogaCenter.Infrastructure.Data.Common;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Core.Services
{
    /// <summary>
    /// AdminService keep all methods which help to connect or disconnect user and role
    /// </summary>
    public class AdminService : IAdminService
    {
        /// <summary>
        /// Use repository to connect to Database
        /// </summary>
        private readonly IRepository repo;
        /// <summary>
        /// Use UserManager to check if user is in role
        /// </summary>
        private readonly UserManager<AppUser> userManager;
        /// <summary>
        /// Use RoleManage to give or remove roles
        /// </summary>
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminService(IRepository _repo,
            UserManager<AppUser> _userManager,
            RoleManager<IdentityRole> _roleManager)
        {
            repo = _repo;
            userManager = _userManager;
            roleManager = _roleManager;
        }

        /// <summary>
        /// This method help to show all Users to the Admin, it take info from database and send it to the View. It also check if the User is in role "Administrator" or not.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// This method create role "Administrator" if there isn`t such role and give the User role "Administrator" after Admin hit the button
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This method remove User from role "Administrator" after Admin hit the button
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Remove(string id)
        {
            var roleName = "Administrator";

            var user = await repo.GetByIdAsync<AppUser>(id);

            if (await userManager.IsInRoleAsync(user, roleName))
            {
                await userManager.RemoveFromRoleAsync(user, roleName);
            }
        }

        /// <summary>
        /// This method set Teacher property IsDeleted to status "true"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
