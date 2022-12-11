using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Infrastructure.Data.Configuration
{

    /// <summary>
    /// Configuration for seeding Post in Database
    /// </summary>
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(new Post()
            {
                Id = 1,
                Title = "What is Yoga?",
                Summary = "Yoga is a physical, mental and spiritual practice that originated in ancient India.",
                Description = "Yoga is a physical, mental and spiritual practice that originated in ancient India." +
                              " First codified by the sage Patanjali in his Yoga Sutras around 400 C.E, the practice was in fact handed down from teacher to student " +
                              "long before this text arose. Traditionally, this was a one-to-one transmission, but since yoga became popular in the West in the 20th century," +
                              " group classes have become the norm.",
                TeacherId = 1,
                Created = new DateTime(2022, 11, 29, 15, 30, 0)


            });
        }
    }
}
