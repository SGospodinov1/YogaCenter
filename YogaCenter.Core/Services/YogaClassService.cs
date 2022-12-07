﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models;
using YogaCenter.Core.Models.Administrator;
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
                    TeacherId = y.TeacherId,
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

        public async Task<IEnumerable<YogaClassViewModel>> GetMyClasses(string userId)
        {
            var user = await repo.AllReadonly<AppUser>()
                .Where(u => u.Id == userId)
                .Include(uy => uy.AppUsersYogaClasses)
                .ThenInclude(y => y.YogaClass)
                .ThenInclude(c => c.Category)
                .Include(uy => uy.AppUsersYogaClasses)
                .ThenInclude(y => y.YogaClass)
                .ThenInclude(t => t.Teacher)
                .ThenInclude(u => u.AppUser)
                .FirstOrDefaultAsync();

            var classes = user.AppUsersYogaClasses
                .OrderBy(d => d.YogaClass.StartTime.Date)
                .ThenBy(t => t.YogaClass.StartTime.Hour)
                .Select(y => new YogaClassViewModel()
                {
                    Id = y.YogaClass.Id,
                    Date = y.YogaClass.StartTime.Date.ToString("dd MM yyyy"),
                    DayOfWeek = y.YogaClass.StartTime.DayOfWeek.ToString(),
                    StartTime = $"{y.YogaClass.StartTime.Hour:d2}:{y.YogaClass.StartTime.Minute:d2}",
                    EndTime = $"{y.YogaClass.EndTime.Hour:d2}:{y.YogaClass.EndTime.Minute:d2}",
                    Name = y.YogaClass.Name,
                    Category = y.YogaClass.Category.Name,
                    Teacher = $"{y.YogaClass.Teacher.AppUser.FirstName} {y.YogaClass.Teacher.AppUser.LastName}",
                    TeacherId = y.YogaClass.TeacherId,
                    Price = y.YogaClass.Price,
                    DateTime = y.YogaClass.StartTime
                })
                .ToList();

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

        public async Task AddToMyClasses(int classId, string userId)
        {
            var user = await repo.All<AppUser>()
                .Include(uy => uy.AppUsersYogaClasses)
                .ThenInclude(y => y.YogaClass)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var yogaClass = await repo.All<YogaClass>()
                .FirstOrDefaultAsync(y => y.Id == classId);

            if (user.AppUsersYogaClasses.FirstOrDefault(y => y.YogaClassId == classId) == null)
            {
                user.AppUsersYogaClasses.Add(new AppUserYogaClass()
                {
                    AppUserId = user.Id,
                    YogaClassId = yogaClass.Id
                });
            }

            await repo.SaveChangesAsync();
        }

        public async Task RemoveFromMyClasses(int classId, string userId)
        {
            var user = await repo.All<AppUser>()
                .Include(uy => uy.AppUsersYogaClasses)
                .ThenInclude(y => y.YogaClass)
                .ThenInclude(c => c.Category)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var yogaClass = user.AppUsersYogaClasses
                .FirstOrDefault(y => y.YogaClass.Id == classId);

            user.AppUsersYogaClasses.Remove(yogaClass);

            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<YogaClassViewModel>> TeacherClasses(string userId)
        {
            
            var classes = await repo.AllReadonly<YogaClass>()
                .Where(t => t.Teacher.AppUserId == userId)
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
                    TeacherId = y.TeacherId,
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

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var categories = await repo.All<Category>().ToListAsync();

            return categories;
        }


        public async Task AddYogaClass(CreateYogaClassViewModel model)
        {
            DateOnly date = DateOnly.Parse(model.Date);

            TimeOnly start = TimeOnly.Parse(model.StartTime);

            TimeOnly end = TimeOnly.Parse(model.EndTime);


            DateTime startTime = new DateTime(date.Year, date.Month, date.Day, start.Hour, start.Minute, 0);
            DateTime endTime = new DateTime(date.Year, date.Month, date.Day, end.Hour, end.Minute, 0);

            var yogaClass = new YogaClass()
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                TeacherId = model.TeacherId,
                Price = model.Price,
                StartTime = startTime,
                EndTime = endTime
            };

            try
            {
                await repo.AddAsync(yogaClass);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("Database failed to save Yoga Class", ex);
            }

        }

        public bool IsDateAndTimeAreValid(CreateYogaClassViewModel model)
        {
            bool result = true;

            DateOnly date = DateOnly.Parse(model.Date);

            TimeOnly start = TimeOnly.Parse(model.StartTime);

            TimeOnly end = TimeOnly.Parse(model.EndTime);


            DateTime startTime = new DateTime(date.Year, date.Month, date.Day, start.Hour, start.Minute, 0);
            DateTime endTime = new DateTime(date.Year, date.Month, date.Day, end.Hour, end.Minute, 0);

            if (startTime < DateTime.Now && endTime < DateTime.Now )
            {
                result = false;
            }

            return result;
        }

        public async Task<bool> IsThereOtherClassInTheSameTime(CreateYogaClassViewModel model)
        {
            bool result = true;

            DateOnly date = DateOnly.Parse(model.Date);

            TimeOnly start = TimeOnly.Parse(model.StartTime);

            TimeOnly end = TimeOnly.Parse(model.EndTime);


            DateTime startTime = new DateTime(date.Year, date.Month, date.Day, start.Hour, start.Minute, 0);
            DateTime endTime = new DateTime(date.Year, date.Month, date.Day, end.Hour, end.Minute, 0);

            var classes = await repo.AllReadonly<YogaClass>()
                .Where(d => d.StartTime.Date == startTime.Date)
                .ToListAsync();

            foreach (var item in classes)
            {
                if ((item.StartTime >= startTime && item.StartTime <= endTime) || (item.EndTime >= startTime && item.EndTime <= endTime))
                {
                    result = false;
                    return result;
                }
            }

            return result;


        }

        public async Task<CreateYogaClassViewModel> GetYogaClassForEdit(int classId)
        {
            var yogaClass = await repo.All<YogaClass>()
                .Include(c => c.Category)
                .FirstOrDefaultAsync(y => y.Id == classId);

            var result = new CreateYogaClassViewModel()
            {
                Id = yogaClass.Id,
                Date = yogaClass.StartTime.Date.ToString("dd MM yyyy"),
                StartTime = $"{yogaClass.StartTime.Hour:d2}:{yogaClass.StartTime.Minute:d2}",
                EndTime = $"{yogaClass.EndTime.Hour:d2}:{yogaClass.EndTime.Minute:d2}",
                Name = yogaClass.Name,
                CategoryId = yogaClass.CategoryId,
                Price = yogaClass.Price,
            };

            return result;
        }

        public async Task EditClass(CreateYogaClassViewModel model)
        {
            var yogaClass = await repo.GetByIdAsync<YogaClass>(model.Id);

            DateOnly date = DateOnly.Parse(model.Date);

            TimeOnly start = TimeOnly.Parse(model.StartTime);

            TimeOnly end = TimeOnly.Parse(model.EndTime);


            DateTime startTime = new DateTime(date.Year, date.Month, date.Day, start.Hour, start.Minute, 0);
            DateTime endTime = new DateTime(date.Year, date.Month, date.Day, end.Hour, end.Minute, 0);

            yogaClass.Name = model.Name;
            yogaClass.CategoryId = model.CategoryId;
            yogaClass.StartTime = startTime;
            yogaClass.EndTime = endTime;
            yogaClass.Price = model.Price;
            yogaClass.IsEdited = true;


            await repo.SaveChangesAsync();
        }

        public async Task DeleteClass(int classId)
        {

            await repo.DeleteAsync<YogaClass>(classId);

            await repo.SaveChangesAsync();

        }
    }
}
