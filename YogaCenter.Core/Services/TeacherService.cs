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
    }
}
