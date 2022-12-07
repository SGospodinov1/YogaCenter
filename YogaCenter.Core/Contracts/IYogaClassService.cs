using YogaCenter.Core.Models;
using YogaCenter.Core.Models.Administrator;
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

        Task<IEnumerable<YogaClassViewModel>> TeacherClasses(string userId);

        Task<IEnumerable<Category>> GetAllCategoriesAsync();


        Task AddYogaClass(CreateYogaClassViewModel model);

        bool IsDateAndTimeAreValid(CreateYogaClassViewModel model);

        Task<bool> IsThereOtherClassInTheSameTime(CreateYogaClassViewModel model);


        Task<CreateYogaClassViewModel> GetYogaClassForEdit(int classId);

        Task EditClass(CreateYogaClassViewModel model);

        Task DeleteClass(int classId);
    }
}
