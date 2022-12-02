using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models;
using YogaCenter.Core.Models.Administrator;
using YogaCenter.Infrastructure.Data.Common;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Core.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository repo;
        
        public TeacherService(IRepository _repo)
        {
            repo =_repo;
            
        }

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

        public async Task<bool> IsTeacher(string userId)
        {
            bool result = true;

            var teacher = await repo.AllReadonly<Teacher>()
                .Where(t => t.AppUserId == userId)
                .ToListAsync();

            if (teacher.Count == 0)
            {
                result = false;
            }


            return result;
        }

        public async Task<IEnumerable<TeacherViewModel>> GetAllTeachers()
        {
            var teachers = await repo.AllReadonly<Teacher>()
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

        public async Task EditInfo(InfoDetailsViewModel model)
        {
            var teacher = await repo.GetByIdAsync<Teacher>(model.Id);

            teacher.Description = model.Description;
            

            await repo.SaveChangesAsync();

        }


        public async Task<int> FindTeacherId(string userId)
        {
            var teacher = await repo.All<Teacher>()
                .FirstOrDefaultAsync(t => t.AppUserId == userId);

            return teacher.Id;
        }

    }
}
