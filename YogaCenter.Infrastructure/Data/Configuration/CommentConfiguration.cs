using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Infrastructure.Data.Configuration
{

    /// <summary>
    /// /Configuration for seeding Comment in Database
    /// </summary>
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(new Comment()
            {
                Id = 1,
                Descrtiption = "This class was perfect",
                AppUserId = "8175b008 - d14c - 4214 - 9e7e - 8dc0bdfa6b0c",
                YogaClassId = 1

            });
        }
    }
}
