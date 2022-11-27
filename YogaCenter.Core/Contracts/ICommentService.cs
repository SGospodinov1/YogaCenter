using YogaCenter.Core.Models;

namespace YogaCenter.Core.Contracts
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentViewModel>> GetAll(int yogaClassId);

        Task Add(int yogaClassId);
    }
}
