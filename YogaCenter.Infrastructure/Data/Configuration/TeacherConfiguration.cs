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
                Mail = "teacher@mail.com",
                UserId = "a55ed520-f40e-4285-b089-b5ecd84961b3"
            });
        }
    }
}
