using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Infrastructure.Data.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Hatha Yoga"
                },

                new Category()
                {
                    Id = 2,
                    Name = "Ashtanga Yoga"
                },

                new Category()
                {
                    Id = 3,
                    Name = "Iyengar Yoga"
                },

                new Category()
                {
                    Id = 4,
                    Name = "Vinyasa Yoga"
                },

                new Category()
                {
                    Id = 4,
                    Name = "In Yoga"
                }



             };

            return categories;
        }
    }
}
