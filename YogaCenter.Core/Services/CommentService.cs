using Microsoft.EntityFrameworkCore;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models;
using YogaCenter.Infrastructure.Data.Common;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repo;

        public CommentService(IRepository _repo)
        {
            repo = _repo;

        }
        public async Task<IEnumerable<CommentViewModel>> GetAll(int yogaClassId)
        {
            var yogaClass = await repo.AllReadonly<YogaClass>()
                .Include(c => c.Comments)
                .ThenInclude(u => u.AppUser)
                .FirstOrDefaultAsync(y => y.Id == yogaClassId);


            var comments = yogaClass
                .Comments
                .Select(c => new CommentViewModel()
                {
                    Description = c.Descrtiption,
                    FullName = $"{c.AppUser.FirstName} {c.AppUser.LastName}",
                    YogaClassId = yogaClass.Id
                })
                .ToList();

            return comments;




        }

        public async Task Add(CommentViewModel model)
        {
            var yogaClass = await repo.GetByIdAsync<YogaClass>(model.YogaClassId);

            var comment = new Comment()
            {
                Descrtiption = model.Description,
                AppUserId = model.AppUserId,
                YogaClassId = yogaClass.Id
            };

            yogaClass.Comments.Add(comment);

            await repo.SaveChangesAsync();

        }

        public async Task<string> YogaClassName(int yogaClassId)
        {
            var yogaClass = await repo.GetByIdAsync<YogaClass>(yogaClassId);

            return yogaClass.Name;
        }

        public async Task<string> UserFullName(string userId)
        {
            var user = await repo.GetByIdAsync<AppUser>(userId);

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
