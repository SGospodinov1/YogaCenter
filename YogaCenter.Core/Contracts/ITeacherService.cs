

using YogaCenter.Core.Models;
using YogaCenter.Core.Models.Administrator;

namespace YogaCenter.Core.Contracts
{
    public interface ITeacherService
    {
        Task AddNewTeacher(NewTeacherViewModel model);

        public Task<bool> IsTeacher(string userId);

        public Task<IEnumerable<TeacherViewModel>> GetAllTeachers();

    }
}
