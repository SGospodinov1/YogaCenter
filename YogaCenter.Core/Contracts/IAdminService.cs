using YogaCenter.Core.Models.Admin;

namespace YogaCenter.Core.Contracts
{
    public interface IAdminService
    {
        public Task<IEnumerable<AddUserToRoleViewModel>> AddUsers();
    }
}
