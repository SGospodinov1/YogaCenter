using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models.Administrator;
using YogaCenter.Core.Services;
using YogaCenter.Infrastructure.Data.DataModels;
using YogaCenter.Tests.UnitTests;

namespace YogaCenter.Tests.Tests
{
    [TestFixture]
    public class TeacherServiceTests : UnitTestsBase
    {

        private ITeacherService teacherService;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.teacherService = new TeacherService(this.repo);
        }

        [Test]
        public void AddNewTeacher_IsTeacherAddedToTheDb()
        {
            var model = new NewTeacherViewModel()
            {
                Description = "I`m your Admin",
                AppUserId = "AdminId"
            };

            var result = teacherService.AddNewTeacher(model);

            var teacher = repo.GetByIdAsync<Teacher>(4);

            Assert.IsNotNull(teacher);
            Assert.AreEqual(model.AppUserId, teacher.Result.AppUserId);
            Assert.AreEqual(model.Description, teacher.Result.Description);

        }

        [Test]
        public void IsTeacher_IsResultCorrectWhenUserIsTeacher()
        {
            var result = teacherService.IsTeacher("TeacherId");

            Assert.IsTrue(result.Result);
        }

        [Test]
        public void IsTeacher_IsResultCorrectWhenUserIsNotTeacher()
        {
            var result = teacherService.IsTeacher("UserId");

            Assert.IsFalse(result.Result);
        }

        [Test]
        public void GetAllTeachers_IsTheCountCorrect()
        {
            var result = teacherService.GetAllTeachers();

            Assert.AreEqual(4, result.Result.Count());
        }

        [Test]
        public void MyInfo_CheckIfResultIsCorrect()
        {
            var teacher = repo.GetByIdAsync<Teacher>(1);

            var result = teacherService.MyInfo("TeacherId");

            Assert.AreEqual(teacher.Result.AppUser.FirstName, result.Result.FirstName);
            Assert.AreEqual(teacher.Result.AppUser.LastName, result.Result.LastName);
            Assert.AreEqual(teacher.Result.AppUser.Email, result.Result.Email);
            Assert.AreEqual(teacher.Result.Description, result.Result.Description);
        }

        [Test]
        public void InfoDetailsById_CheckIfResultIsCorrect()
        {
            var model = new InfoDetailsViewModel()
            {
                Id = 2,
                Description = "I`m your best teacher."
            };

            var result = teacherService.InfoDetailsById(2);

            Assert.AreEqual(model.Id, result.Result.Id);
            Assert.AreEqual(model.Description, result.Result.Description);

        }

        [Test]
        public void EditInfo_IsDescriptionChange()
        {
            var model = new InfoDetailsViewModel()
            {
                Id = 1,
                Description = "Best teacher ever."
            };

            var result = teacherService.EditInfo(model);

            var teacher = repo.GetByIdAsync<Teacher>(1);

            Assert.AreEqual(model.Description, teacher.Result.Description);
        }

        [Test]
        public void FindTeacherId_IsIdFound()
        {
            var result = teacherService.FindTeacherId("TeacherId");

            Assert.AreEqual(1, result.Result);
        }

    }
}
