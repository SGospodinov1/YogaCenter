using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Infrastructure.Data.Configuration
{
    internal class YogaClassConfiguration : IEntityTypeConfiguration<YogaClass>
    {
        public void Configure(EntityTypeBuilder<YogaClass> builder)
        {
            builder.HasData(CreateYogaClass());
        }

        private List<YogaClass> CreateYogaClass()
        {
            List<YogaClass> classes = new List<YogaClass>()
            {
                new YogaClass
                {
                    Id = 1,
                    Name = "Balance and clear your mind",
                    StartTime = new DateTime(2022,11,11,18,0,0),
                    EndTime = new DateTime(2022,11,11,19,30,0),
                    Price = 15,
                    CategoryId = 1,
                    TeacherId = 1,
                    
                },

                new YogaClass
                {
                    Id = 2,
                    Name = "Dinamic Viniasa with Krisi",
                    StartTime = new DateTime(2022,11,11,20,0,0),
                    EndTime = new DateTime(2022,11,11,21,30,0),
                    Price = 20,
                    CategoryId = 4,
                    TeacherId = 1,

                }
            };

            return classes;
        }
    }
}
