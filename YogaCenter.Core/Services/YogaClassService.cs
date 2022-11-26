using Microsoft.EntityFrameworkCore;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models;
using YogaCenter.Infrastructure.Data.Common;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Core.Services
{
    public class YogaClassService : IYogaClassService
    {
        private readonly IRepository repo;

        public YogaClassService(IRepository _repo)
        {
            repo = _repo;
        }



        public async Task<IEnumerable<YogaClassViewModel>> GetAll()
        {
            var classes = await repo.AllReadonly<YogaClass>()
                .OrderBy(d => d.StartTime.Date)
                .ThenBy(t => t.StartTime.Hour)
                .Select(y => new YogaClassViewModel()
                {
                    Id = y.Id,
                    Date = y.StartTime.Date.ToString("dd MM yyyy"),
                    DayOfWeek = y.StartTime.DayOfWeek.ToString(),
                    StartTime = $"{y.StartTime.Hour:d2}:{y.StartTime.Minute:d2}",
                    EndTime = $"{y.EndTime.Hour:d2}:{y.EndTime.Minute:d2}",
                    Name = y.Name,
                    Category = y.Category.Name,
                    Teacher = $"{y.Teacher.AppUser.FirstName} {y.Teacher.AppUser.LastName}",
                    Price = y.Price,
                    DateTime = y.StartTime
                    
                })
                .ToListAsync();

            var users = await repo.AllReadonly<AppUserYogaClass>()
                .Include(u => u.AppUser)
                .ToListAsync();

            foreach (var c in classes)
            {
                foreach (var u in users)
                {
                    if (u.YogaClassId == c.Id)
                    {
                        c.Users.Add(u.AppUserId);
                    }
                }
            }

            return classes;
        }

        public async Task<AppUser> GetUser(string id)
        {
            var user = await repo.All<AppUser>()
                .Include(uy => uy.AppUsersYogaClasses)
                .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }
    }
}
