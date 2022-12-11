using YogaCenter.Core.Models.Admin;

namespace YogaCenter.Core.Contracts
{
    /// <summary>
    /// Interface for AdminService
    /// </summary>
    public interface IAdminService
    {
        Task<IEnumerable<UserViewModel>> AllUsers();

        Task Add(string id);

        Task Remove(string id);

        Task RemoveTeacher(string id);
    }
}
