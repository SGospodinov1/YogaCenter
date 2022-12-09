using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models.Administrator;
using YogaCenter.Core.Services;
using YogaCenter.Infrastructure.Data.DataModels;
using YogaCenter.Tests.UnitTests;

namespace YogaCenter.Tests.Tests
{
    [TestFixture]
    public class PostServiceTests : UnitTestsBase
    {
        private IPostService postService;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.postService = new PostService(this.repo);
        }

        [Test]
        public void AllPosts_CheckTheCountOfAllPosts()
        {
            var posts = this.postService.AllPosts();

            Assert.AreEqual(2, posts.Result.Count());
        }

        [Test]
        public void MyPosts_CheckTheCountOfTeacherPosts()
        {
            var posts = postService.MyPosts("TeacherId");


            Assert.AreEqual(1, posts.Result.Count());
        }

        [Test]
        public void FindPost_CheckDataOfDescriptionAndTeacherName()
        {
            var post = postService.FindPost(1);

            Assert.AreEqual("Test this post", post.Result.Description);
            Assert.AreEqual("Katq Ivanova", post.Result.CreatedBy);
        }

        [Test]
        public void CreatePost_IsPostSuccessfulyAdded()
        {
            var model = new CreateNewPostViewModel()
            {
                Title = "Wath is Yoga?",
                Summary = "Yoga is a discipline.",
                Description = "Yoga is a discipline.Ït helps people to leave better.",
                Created = DateTime.Now,
                TeacherId = 3
            };
            
            var post = postService.CreatePost(model);

            var result = repo.GetByIdAsync<Post>(3);

            Assert.IsNotNull(post);
            Assert.IsNotNull(result);
            Assert.AreEqual("Wath is Yoga?", result.Result.Title);
            Assert.AreEqual("Yoga is a discipline.", result.Result.Summary);
            Assert.AreEqual("Yoga is a discipline.Ït helps people to leave better.", result.Result.Description);
        }

        [Test]
        public void GetPostForEdit_IsDataCorrect()
        {
            var result = postService.GetPostForEdit(1);

            Assert.AreEqual("Test Title", result.Result.Title);
            Assert.AreEqual("TestSummary", result.Result.Summary);
            Assert.AreEqual("Test this post", result.Result.Description);
            
        }

        [Test]
        public void EditPost_AreChangesMadeCorrect()
        {
            var model = new CreateNewPostViewModel()
            {
                Id = 2,
                Title = "Find peace and happiness",
                Summary = "This test is OK",
                Description = "This test is OK. I`m happy"
            };

            var post = postService.EditPost(model);

            var result = repo.GetByIdAsync<Post>(2);

            Assert.AreEqual("Find peace and happiness", result.Result.Title);
            Assert.AreEqual("This test is OK", result.Result.Summary);
            Assert.AreEqual("This test is OK. I`m happy", result.Result.Description);
        }

        [Test]
        public void DeletePost_IsDeleteIsSuccessful()
        {
            var result = postService.DeletePost(3);

            var posts = repo.AllReadonly<Post>();

            var post = repo.AllReadonly<Post>()
                .Where(p => p.Id == 3);

            Assert.AreEqual(2, posts.Count());
            Assert.IsEmpty(post);
        }

    }
}
