using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models;
using YogaCenter.Core.Models.Administrator;
using YogaCenter.Infrastructure.Data.Common;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Core.Services
{
    /// <summary>
    /// TeacherService keep all methods that are connected to Teachers
    /// </summary>
    public class TeacherService : ITeacherService
    {
        /// <summary>
        /// Use repository to connect to Database
        /// </summary>
        private readonly IRepository repo;

        public TeacherService(IRepository _repo)
        {
            repo = _repo;

        }

        /// <summary>
        /// This method is used to add new Teacher in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddNewTeacher(NewTeacherViewModel model)
        {

            var teacher = new Teacher()
            {
                Description = model.Description,
                AppUserId = model.AppUserId
            };

            await repo.AddAsync(teacher);
            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// This method check if the User is Teacher or not. Also if Teacher was removed from role and afterthat returned to role the method find him and change IsDeleted status to "false"
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> IsTeacher(string userId)
        {
            bool result = true;

            var teacher = await repo.AllReadonly<Teacher>()
                .FirstOrDefaultAsync(t => t.AppUserId == userId);

            if (teacher == null)
            {
                result = false;
            }
            else
            {
                if (teacher.IsDeleted == true)
                {
                    var oldTeacher = await repo.GetByIdAsync<Teacher>(teacher.Id);

                    oldTeacher.IsDeleted = false;
                    await repo.SaveChangesAsync();
                }
                
            }


            return result;
        }

        /// <summary>
        /// This method take all teachers info to show it to Users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TeacherViewModel>> GetAllTeachers()
        {
            var teachers = await repo.AllReadonly<Teacher>()
                .Where(t => t.IsDeleted == false)
                .Select(t => new TeacherViewModel()
                {
                    Id = t.Id,
                    FullName = $"{t.AppUser.FirstName} {t.AppUser.LastName}",
                    Description = t.Description,
                    Email = t.AppUser.Email
                })
                .ToListAsync();

            return teachers;
        }

        /// <summary>
        /// This method give to Teacher information about himself/herself
        /// </summary>
        /// <param name="usrId"></param>
        /// <returns></returns>
        public async Task<MyInfoViewModel> MyInfo(string usrId)
        {
            var teacher = await repo.AllReadonly<Teacher>()
                .Include(u => u.AppUser)
                .FirstOrDefaultAsync(t => t.AppUser.Id == usrId);

            var result = new MyInfoViewModel()
            {
                Id = teacher.Id,
                AppUserId = teacher.AppUserId,
                FirstName = teacher.AppUser.FirstName,
                LastName = teacher.AppUser.LastName,
                Email = teacher.AppUser.Email,
                Description = teacher.Description
            };

            return result;
        }

        /// <summary>
        /// This method is used to find the Teacher in database and add its information in the Edit View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<InfoDetailsViewModel> InfoDetailsById(int id)
        {
            var teacher = await repo.AllReadonly<Teacher>()
                .Include(u => u.AppUser)
                .FirstOrDefaultAsync(t => t.Id == id);

            var result = new InfoDetailsViewModel()
            {
                Id = teacher.Id,
                Description = teacher.Description
            };

            return result;
        }

        /// <summary>
        /// This method is used to add edited Teacher description to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task EditInfo(InfoDetailsViewModel model)
        {
            var teacher = await repo.GetByIdAsync<Teacher>(model.Id);

            teacher.Description = model.Description;
            

            await repo.SaveChangesAsync();

        }

        /// <summary>
        /// This method is used to give Id of the Teacher
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> FindTeacherId(string userId)
        {
            var teacher = await repo.All<Teacher>()
                .FirstOrDefaultAsync(t => t.AppUserId == userId);

            return teacher.Id;
        }

    }
}
