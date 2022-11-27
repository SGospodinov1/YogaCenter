using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models;

namespace YogaCenter.Core.Services
{
    public class CommentService : ICommentService
    {
        public Task<IEnumerable<CommentViewModel>> GetAll(int yogaClassId)
        {
            throw new NotImplementedException();
        }

        public Task Add(int yogaClassId)
        {
            throw new NotImplementedException();
        }
    }
}
