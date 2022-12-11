

using YogaCenter.Core.Models;
using YogaCenter.Core.Models.Administrator;

namespace YogaCenter.Core.Contracts
{

    /// <summary>
    /// Interface for TeacherService
    /// </summary>
    public interface ITeacherService
    {
        Task AddNewTeacher(NewTeacherViewModel model);

        Task<bool> IsTeacher(string userId);

        Task<IEnumerable<TeacherViewModel>> GetAllTeachers();

        Task<MyInfoViewModel> MyInfo(string usrId);

        Task<InfoDetailsViewModel> InfoDetailsById(int id);

        Task EditInfo(InfoDetailsViewModel model);

        Task<int> FindTeacherId(string userId);

    }
}
