using Microsoft.EntityFrameworkCore;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models;
using YogaCenter.Infrastructure.Data.Common;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Core.Services
{
    /// <summary>
    /// CommentService keep all methods that are connected to Comments
    /// </summary>
    public class CommentService : ICommentService
    {
        /// <summary>
        /// Use repository to connect to Database
        /// </summary>
        private readonly IRepository repo;

        public CommentService(IRepository _repo)
        {
            repo = _repo;

        }
        /// <summary>
        /// This method give information about all Comments in given YogaClass. It extract description and fullname of the User.
        /// </summary>
        /// <param name="yogaClassId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This method add new Comment to specific YogaClass
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This method return the name of the YogaClass and its information is used in the View on top of all comments.
        /// </summary>
        /// <param name="yogaClassId"></param>
        /// <returns></returns>
        public async Task<string> YogaClassName(int yogaClassId)
        {
            var yogaClass = await repo.GetByIdAsync<YogaClass>(yogaClassId);

            return yogaClass.Name;
        }

        /// <summary>
        /// This method find User in Database and return its FullName
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<string> UserFullName(string userId)
        {
            var user = await repo.GetByIdAsync<AppUser>(userId);

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
