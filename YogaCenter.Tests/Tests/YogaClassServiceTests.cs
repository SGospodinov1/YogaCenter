using Castle.Core.Logging;
using Moq;
using NUnit.Framework.Internal;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models.Administrator;
using YogaCenter.Core.Services;
using YogaCenter.Infrastructure.Data.DataModels;
using YogaCenter.Tests.Mocks;

namespace YogaCenter.Tests.UnitTests
{
    [TestFixture]
    public class YogaClassServiseTests : UnitTestsBase
    {
        private IYogaClassService yogaClassService;
        

        [OneTimeSetUp]
        public void SetUp()
        {
            this.yogaClassService = new YogaClassService(this.repo);
        }

        [Test]
        public void GetAll_ShouldReturnCorrectCount()
        {
            var resultCount = yogaClassService.GetAll();

            Assert.NotNull(resultCount);
            Assert.AreEqual(2, resultCount.Result.Count());
        }


        [Test]
        public void GetUser_ShouldReturnCorrectInfo()
        {
            var result = yogaClassService.GetUser("Teacher1Id");

            Assert.AreEqual("teacher1@mail.com", result.Result.Email);
            Assert.AreEqual("Petq", result.Result.FirstName);
            Assert.AreEqual("Petrova", result.Result.LastName);

        }


        [Test]
        public void GetMyClasses_ShouldReturnCorrectCount()
        {
            var classes = yogaClassService.GetMyClasses("UserId");

            var result = repo.All<AppUserYogaClass>()
                .Where(u => u.AppUserId == "UserId")
                .ToList();

            Assert.AreEqual(1, result.Count);

        }

        [Test]
        public void GetMyClasses_ShouldReturnCorrectClassName()
        {
            var result = yogaClassService.GetMyClasses("UserId");

            Assert.IsTrue(result.Result.Any(n => n.Name == "Hatha Yoga"));
        }

        [Test]
        public void AddToMyClasses_FindThatUserIsInThisClass()
        {
            var result = yogaClassService.AddToMyClasses(2, "User1Id");

            var userCLasses = repo.All<AppUserYogaClass>().Where(u => u.AppUserId == "User1Id");

            Assert.AreEqual(1, userCLasses.Count());
        }

        [Test]
        public void RemoveFromMyClasses_FindThatUserIsNotInThatCLass()
        {
            var result = yogaClassService.RemoveFromMyClasses(2, "User1Id");

            var userCLasses = repo.All<AppUserYogaClass>().Where(u => u.AppUserId == "User1Id");

            Assert.AreEqual(0, userCLasses.Count());
        }

        [Test]
        public void TeacherClasses_CheckIfAllReturnedClassesHaveTeacherWithUserId()
        {
            var teacher = repo.All<Teacher>()
                .FirstOrDefault(t => t.AppUserId == "TeacherId");

            var result = yogaClassService.TeacherClasses("TeacherId");

            bool isTheSameTeacher = true;

            foreach (var item in result.Result)
            {
                if (item.TeacherId != teacher.Id)
                {
                    isTheSameTeacher = false;
                }
            }

            Assert.IsTrue(isTheSameTeacher);
            Assert.AreEqual(1, result.Result.Count());

        }

        [Test]
        public void GetAllCategoriesAsync_CheckTheCount()
        {
            var result = yogaClassService.GetAllCategoriesAsync();

            Assert.AreEqual(2, result.Result.Count());
        }

        [Test]
        public void AddYogaClass_CheckIfTheClassIsSavedSuccessfuly()
        {
            var model = new CreateYogaClassViewModel()
            {
                Name = "DinamicYoga",
                CategoryId = 1,
                Date = "10.12.2022",
                StartTime = "10:00",
                EndTime = "11:30",
                TeacherId = 3,
                Price = 10M
            };

            yogaClassService.AddYogaClass(model);

            DateTime time = new DateTime(2022, 12, 10, 10, 00, 0);

            var result = repo.All<YogaClass>()
                .FirstOrDefault(y => y.Name == "DinamicYoga");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.CategoryId);
            Assert.AreEqual(1, result.TeacherId);
            Assert.AreEqual(10M, result.Price);
            Assert.AreEqual(time, result.StartTime);
        }


    }
}



