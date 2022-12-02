
using YogaCenter.Core.Models;
using YogaCenter.Core.Models.Administrator;

namespace YogaCenter.Core.Contracts
{
    public interface IPostService
    {
        Task<IEnumerable<PostViewModel>> AllPosts();

        Task<IEnumerable<PostViewModel>> MyPosts(string userId);

        Task<PostDetailsViewModel> FindPost(int postId);

        Task CreatePost(CreateNewPostViewModel model);

        Task<CreateNewPostViewModel> GetPostForEdit(int postId);

        Task EditPost(CreateNewPostViewModel model);

        Task DeletePost(int postId);



    }
}
