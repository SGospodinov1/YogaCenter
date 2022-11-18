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

        public AdminService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<AddUserToRoleViewModel>> AddUsers()
        {
            var users = await repo.AllReadonly<AppUser>()
                .Select(u => new AddUserToRoleViewModel()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email
                })
                .ToListAsync();

            return users;
        }
    }
}
