using Microsoft.EntityFrameworkCore;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models;
using YogaCenter.Infrastructure.Data.Common;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Core.Services
{
    public class YogaClassScheduleService : IYogaClassScheduleService
    {
        private readonly IRepository repo;

        public YogaClassScheduleService(IRepository _repo)
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
                    Date = y.StartTime.Date.ToString(),
                    DayOfWeek = y.StartTime.DayOfWeek.ToString(),
                    StartTime = $"{y.StartTime.Hour}:{y.StartTime.Minute}",
                    EndTime = $"{y.StartTime.Hour}:{y.StartTime.Minute}",
                    Name = y.Name,
                    Category = y.Category.Name,
                    Teacher = $"{y.Teacher.FirstName} {y.Teacher.LastName}",
                    Price = y.Price

                })
                .ToListAsync();

            return classes;
        }
    }
}
