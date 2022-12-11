using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework.Constraints;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Models.Administrator;
using YogaCenter.Core.Services;
using YogaCenter.Infrastructure.Data.DataModels;


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
                Date = "2022-12-29",
                StartTime = "10:00",
                EndTime = "11:30",
                TeacherId = 3,
                Price = 10M
            };

            yogaClassService.AddYogaClass(model);

            DateTime time = new DateTime(2022, 12, 29, 10, 00, 0);

            var result = repo.All<YogaClass>()
                .FirstOrDefault(y => y.Name == "DinamicYoga");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.CategoryId);
            Assert.AreEqual(3, result.TeacherId);
            Assert.AreEqual(10M, result.Price);
            Assert.AreEqual(time, result.StartTime);
        }

        [Test]
        public void DeleteClass_IsDeleteIsSuccessful()
        {
            var result = yogaClassService.DeleteClass(3);

            var yogaClass = repo.All<YogaClass>()
                .ToList();

            bool IsThereSuchClass = false;

            foreach (var item in yogaClass)
            {
                if (item.Id == 3)
                {
                    IsThereSuchClass = true;
                }
            }

            Assert.AreEqual(false, IsThereSuchClass);
        }

        [Test]
        public void IsDateAndTimeAreValid_IsWorkingProperlyForOldDates()
        {
            var model = new CreateYogaClassViewModel()
            {
                Name = "DinamicYoga",
                CategoryId = 1,
                Date = "2022-11-10",
                StartTime = "10:00",
                EndTime = "11:30",
                TeacherId = 3,
                Price = 10M
            };

            var result = yogaClassService.IsDateAndTimeAreValid(model);

            Assert.IsFalse(result);

        }

        [Test]
        public void IsDateAndTimeAreValid_IsWorkingProperlyForFutureDates()
        {
            var model = new CreateYogaClassViewModel()
            {
                Name = "Yoga",
                CategoryId = 1,
                Date = "2023-12-28",
                StartTime = "17:00",
                EndTime = "18:30",
                TeacherId = 3,
                Price = 10M
            };

            var result = yogaClassService.IsDateAndTimeAreValid(model);

            Assert.IsTrue(result);

        }

        [Test]
        public void IsThereOtherClassInTheSameTime_IsWorkingProperlyIfThereIsNoClass()
        {
            var model = new CreateYogaClassViewModel()
            {
                Name = "DinamicYoga",
                CategoryId = 1,
                Date = "2023-3-12",
                StartTime = "10:00",
                EndTime = "11:30",
                TeacherId = 3,
                Price = 10M
            };

            var result = yogaClassService.IsThereOtherClassInTheSameTime(model);

            Assert.IsFalse(result.Result);

        }

        [Test]
        public void IsThereOtherClassInTheSameTime_IsWorkingProperlyIfThereIsAClass()
        {
            var model = new CreateYogaClassViewModel()
            {
                Name = "Yoga",
                CategoryId = 1,
                Date = "2022-12-28",
                StartTime = "17:00",
                EndTime = "18:30",
                TeacherId = 3,
                Price = 10M
            };

            var result = yogaClassService.IsThereOtherClassInTheSameTime(model);

            Assert.IsTrue(result.Result);



        }

        [Test]
        public void GetYogaClassForEdit_IsDataExtractedCorectly()
        {
            var yogaClass = new CreateYogaClassViewModel()
            {
                Id = 1,
                Date = "2022-12-28",
                StartTime = "18:00",
                EndTime = "19:30",
                Name = "Hatha Yoga",
                CategoryId = 1,
                Price = 15M,

            };

            var result = yogaClassService.GetYogaClassForEdit(1);

            Assert.AreEqual(yogaClass.Id,result.Result.Id);
            Assert.AreEqual(yogaClass.Date, result.Result.Date);
            Assert.AreEqual(yogaClass.StartTime, result.Result.StartTime);
            Assert.AreEqual(yogaClass.EndTime, result.Result.EndTime);
            Assert.AreEqual(yogaClass.Name, result.Result.Name);
            Assert.AreEqual(yogaClass.CategoryId, result.Result.CategoryId);
            Assert.AreEqual(yogaClass.Price, result.Result.Price);
        }

        [Test]
        public void EditClass_AreChangesAreSuccesssful()
        {
            var model = new CreateYogaClassViewModel()
            {
                Id = 2,
                Date = "2022-12-21",
                StartTime = "10:00",
                EndTime = "11:30",
                Name = "Find Peace With In Yoga",
                CategoryId = 2,
                Price = 15M,

            };

            var result = yogaClassService.EditClass(model);

            var yogaClass = repo.GetByIdAsync<YogaClass>(2);

            string date = $"{yogaClass.Result.StartTime.Year}-{yogaClass.Result.StartTime.Month}-{yogaClass.Result.StartTime.Day}";
            string start = $"{yogaClass.Result.StartTime.Hour:d2}:{yogaClass.Result.StartTime.Minute:d2}";
            string end = $"{yogaClass.Result.EndTime.Hour:d2}:{yogaClass.Result.EndTime.Minute:d2}";

            Assert.AreEqual(model.Id, yogaClass.Result.Id);
            Assert.AreEqual(model.Date, date);
            Assert.AreEqual(model.StartTime, start);
            Assert.AreEqual(model.EndTime, end);
            Assert.AreEqual(model.Name, yogaClass.Result.Name);
            Assert.AreEqual(model.CategoryId, yogaClass.Result.CategoryId);
            Assert.AreEqual(model.Price, yogaClass.Result.Price);

        }

        [Test]
        public void DeleteClass_IsDeleted()
        {
            var result = yogaClassService.DeleteClass(4);

            var yclass = repo.AllReadonly<Post>()
                .Where(p => p.Id == 4);

            Assert.IsEmpty(yclass);
        }


    }
}


