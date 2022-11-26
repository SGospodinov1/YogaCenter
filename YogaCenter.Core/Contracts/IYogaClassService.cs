using YogaCenter.Core.Models;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Core.Contracts
{
    public interface IYogaClassService
    {
        Task<IEnumerable<YogaClassViewModel>> GetAll();

        Task<AppUser> GetUser(string id);
    }
}
