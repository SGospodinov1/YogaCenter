using YogaCenter.Core.Models;

namespace YogaCenter.Core.Contracts
{
    public interface IYogaClassScheduleService
    {
        Task<IEnumerable<YogaClassViewModel>> GetAll();
    }
}
