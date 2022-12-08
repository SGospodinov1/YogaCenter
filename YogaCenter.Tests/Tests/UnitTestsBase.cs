using Castle.Core.Logging;
using YogaCenter.Infrastructure.Data;
using YogaCenter.Infrastructure.Data.Common;
using YogaCenter.Infrastructure.Data.DataModels;
using YogaCenter.Tests.Mocks;

namespace YogaCenter.Tests.UnitTests
{
    public class UnitTestsBase
    {

        protected IRepository repo;





        public AppUser User { get; private set; }
        public YogaClass YogaClass { get; private set; }
        public Teacher Teacher { get; private set; }
        public Comment Comment { get; private set; }
        public Post Post { get; private set; }
        public AppUserYogaClass AppUserYogaClass { get; private set; }
        public Category Category { get; private set; }


        [OneTimeSetUp]
        public void SetUpBase()
        {

            this.repo = RepositoryMock.Instance;

            this.SeedDatabase();
        }

        private void SeedDatabase()
        {
            var users = new List<AppUser>()
            {
                new AppUser()
                {
                    Id = "AdminId",
                    Email = "admin@admin.com",
                    FirstName = "Ivan",
                    LastName = "Ivanov"
                },

                new AppUser()
                {
                    Id = "UserId",
                    Email = "user@mail.com",
                    FirstName = "Petur",
                    LastName = "Petrov"
                },

                new AppUser()
                {
                    Id = "User1Id",
                    Email = "user1@mail.com",
                    FirstName = "Galq",
                    LastName = "Miteva"
                },

                new AppUser()
                {
                    Id = "TeacherId",
                    Email = "teacher@mail.com",
                    FirstName = "Katq",
                    LastName = "Ivanova"

                },

                new AppUser()
                {
                    Id = "Teacher1Id",
                    Email = "teacher1@mail.com",
                    FirstName = "Petq",
                    LastName = "Petrova"
                },

                new AppUser()
                {
                Id = "Teacher2Id",
                Email = "teacher2@mail.com",
                FirstName = "Olga",
                LastName = "Hristova"
            }

            };

            this.repo.AddRangeAsync(users);

            var teachers = new List<Teacher>()
            {
                new Teacher()
                {
                    Id = 1,
                    Description = "I`m your teacher.",
                    AppUserId = "TeacherId"
                },

                new Teacher()
                {
                    Id = 2,
                    Description = "I`m your best teacher.",
                    AppUserId = "Teacher1Id"
                },

                new Teacher()
                {
                    Id = 3,
                    Description = "I`m your best best teacher.",
                    AppUserId = "Teacher2Id"
                }

            };

            this.repo.AddRangeAsync(teachers);

            var yogaCLasses = new List<YogaClass>()
            {
                new YogaClass()
                {
                    Id = 1,
                    Name = "Hatha Yoga",
                    StartTime = new DateTime(2022, 12, 28, 18, 00, 0),
                    EndTime = new DateTime(2022, 12, 28, 19, 30, 0),
                    CategoryId = 1,
                    TeacherId = 1,
                    Price = 15M,
                    AppUsersYogaClasses = new List<AppUserYogaClass>()


                },


                new YogaClass()
                {
                    Id = 2,
                    Name = "In Yoga",
                    StartTime = new DateTime(2022, 12, 20, 9, 00, 0),
                    EndTime = new DateTime(2022, 12, 20, 10, 30, 0),
                    CategoryId = 2,
                    TeacherId = 2,
                    Price = 20M,
                    AppUsersYogaClasses = new List<AppUserYogaClass>()
                }



            };


            this.repo.AddRangeAsync(yogaCLasses);

            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Hatha"
                },

                new Category()
                {
                    Id = 2,
                    Name = "In"
                }

            };

            this.repo.AddRangeAsync(categories);

            var posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "Test Title",
                    Summary = "TestSummary",
                    Description = "Test this post",
                    TeacherId = 1,
                    Created = new DateTime(2022, 12, 3, 12, 30, 0)
                },

                new Post()
                {
                    Id = 2,
                    Title = "Test Test Title",
                    Summary = "TestTestSummary",
                    Description = "Test test this post",
                    TeacherId = 2,
                    Created = new DateTime(2022, 12, 1, 14, 30, 0)
                }
            };

            this.repo.AddRangeAsync(posts);


            this.Comment = new Comment()
            {
                Id = 1,
                Descrtiption = "The best class",
                AppUserId = "UserId",
                YogaClassId = 1

            };

            this.repo.AddAsync(this.Comment);

            var appUserClasses = new AppUserYogaClass()
            {
                AppUserId = "UserId",
                YogaClassId = 1
            };

            this.repo.AddAsync(appUserClasses);

            this.repo.SaveChangesAsync();

        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            this.repo.Dispose();
        }
    }
}

