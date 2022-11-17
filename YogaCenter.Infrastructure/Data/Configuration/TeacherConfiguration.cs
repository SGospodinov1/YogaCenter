using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Infrastructure.Data.Configuration
{
    internal class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasData(new Teacher()
            {
                Id = 1,
                Description = "I`m a yoga teacher.",
                AppUserId = "737b8ae9-fff1-41e0-bb81-7ed16a44f1c2"
            });
        }
    }
}
