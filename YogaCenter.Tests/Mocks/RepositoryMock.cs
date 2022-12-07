using Moq;
using YogaCenter.Infrastructure.Data.Common;

namespace YogaCenter.Tests.Mocks
{
    public static class RepositoryMock
    {

        public static Repository Instance
        {
            get
            {
                var repo = new Mock<Repository>(DatabaseMock.Instance);


                return repo.Object;

            }
        }

    }
}
