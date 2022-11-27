using YogaCenter.Core.Models;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Core.Contracts
{
    public interface IYogaClassService
    {
        Task<IEnumerable<YogaClassViewModel>> GetAll();

        Task<AppUser> GetUser(string id);

        Task<IEnumerable<YogaClassViewModel>> GetMyClasses(string userId);

        Task AddToMyClasses(int classId, string userId);

        Task RemoveFromMyClasses(int classId, string userId);
    }
}
