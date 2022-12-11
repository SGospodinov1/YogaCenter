using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models;
using YogaCenter.Core.Models.Administrator;
using YogaCenter.Infrastructure.Data.Common;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Core.Services
{
    /// <summary>
    /// PostService keep all methods that are connected to Posts
    /// </summary>
    public class PostService : IPostService
    {
        /// <summary>
        /// Use repository to connect to Database
        /// </summary>
        private readonly IRepository repo;

        public PostService(IRepository _repo)
        {
            repo = _repo;

        }

        /// <summary>
        /// This method return short information about all Posts
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PostViewModel>> AllPosts()
        {
            var posts = await repo.AllReadonly<Post>()
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Summary = p.Summary,
                    CreatedBy = $"{p.Teacher.AppUser.FirstName} {p.Teacher.AppUser.LastName}"

                })
                .ToListAsync();

            return posts;

        }

        /// <summary>
        /// This method is used to show the Teacher all Posts created by him/her
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PostViewModel>> MyPosts(string userId)
        {
            var posts = await repo.AllReadonly<Post>()
                .Where(p => p.Teacher.AppUserId == userId)
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Summary = p.Summary,
                    CreatedBy = $"{p.Teacher.AppUser.FirstName} {p.Teacher.AppUser.LastName}"

                })
                .ToListAsync();

            return posts;

        }

        /// <summary>
        /// This method is used to  find the specific Post and show detailed information about it.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<PostDetailsViewModel> FindPost(int postId)
        {
            var post = await repo.All<Post>()
                .Include(t => t.Teacher)
                .ThenInclude(u => u.AppUser)
                .FirstOrDefaultAsync(p => p.Id == postId);

            var result = new PostDetailsViewModel()
            {
                Title = post.Title,
                Description = post.Description,
                CreatedBy = $"{post.Teacher.AppUser.FirstName} {post.Teacher.AppUser.LastName}",
                CreatedDate = post.Created
            };

            return result;
        }

        /// <summary>
        /// This method is used to create new Post and add it to the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task CreatePost(CreateNewPostViewModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Summary = model.Summary,
                Description = model.Description,
                Created = DateTime.Now,
                TeacherId = model.TeacherId
            };

            await repo.AddAsync(post);
            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// This method is used to find the Post in database and add its information in the Edit View
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<CreateNewPostViewModel> GetPostForEdit(int postId)
        {
            var post = await repo.GetByIdAsync<Post>(postId);

            var result = new CreateNewPostViewModel()
            {
                Id = post.Id,
                Title = post.Title,
                Summary = post.Summary,
                Description = post.Description
            };


            return result;

        }

        /// <summary>
        /// This method is used to add Edited Post to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task EditPost(CreateNewPostViewModel model)
        {

            var post = await repo.GetByIdAsync<Post>(model.Id);

            post.Title = model.Title;
            post.Summary = model.Summary;
            post.Description = model.Description;

            await repo.SaveChangesAsync();

        }

        /// <summary>
        /// This method is used to delete Post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task DeletePost(int postId)
        {
            await repo.DeleteAsync<Post>(postId);
            await repo.SaveChangesAsync();
        }
    }
}
