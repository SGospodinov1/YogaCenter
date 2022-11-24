using YogaCenter.Core.Models.Admin;

namespace YogaCenter.Core.Contracts
{
    public interface IAdminService
    {
        public Task<IEnumerable<UserViewModel>> AllUsers();

        public Task Add(string id);

        public Task Remove(string id);

        public Task RemoveTeacher(string id);
    }
}
