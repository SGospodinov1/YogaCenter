using Microsoft.EntityFrameworkCore;
using YogaCenter.Infrastructure.Data;

namespace YogaCenter.Tests.Mocks
{
    public static class DatabaseMock
    {

        public static ApplicationDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("YogaCenterInMemoryDb" + DateTime.Now.Ticks.ToString())
                    .Options;

                return new ApplicationDbContext(dbContextOptions, false);
            }
        }

    }
}
