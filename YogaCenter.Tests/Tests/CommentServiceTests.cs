using Microsoft.EntityFrameworkCore;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models;
using YogaCenter.Core.Services;
using YogaCenter.Infrastructure.Data.DataModels;
using YogaCenter.Tests.UnitTests;

namespace YogaCenter.Tests.Tests
{
    [TestFixture]
    public class CommentServiceTests : UnitTestsBase
    {
        private ICommentService commentService;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.commentService = new CommentService(this.repo);
        }

        [Test]
        public void Add_IsAddedToCorrectClass()
        {
            var model = new CommentViewModel()
            {
                AppUserId = "User1Id",
                YogaClassId = 1,
                Description = "I like this teacher",
                FullName = "Galq Miteva"
            };

            var result = commentService.Add(model);

            var comment = repo.AllReadonly<Comment>()
                .FirstOrDefaultAsync(u => u.AppUserId == "User1Id");

            Assert.AreEqual(1, comment.Result.YogaClassId);
            Assert.AreEqual("I like this teacher", comment.Result.Descrtiption);
            
        }

        [Test]
        public void GetAll_IfThereIsCommentInClass()
        {
            var result = commentService.GetAll(1);

            Assert.AreEqual(2, result.Result.Count());
        }

        [Test]
        public void YogaClassName_IsItCorrect()
        {
            var result = commentService.YogaClassName(1);

            Assert.AreEqual("Hatha Yoga", result.Result);
        }

        [Test]
        public void UserFullName_IsItCorrect()
        {
            var result = commentService.UserFullName("User1Id");

            Assert.AreEqual("Galq Miteva", result.Result);
        }

    }
}
