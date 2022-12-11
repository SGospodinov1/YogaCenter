using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Infrastructure.Data.Configuration
{
    /// <summary>
    /// Configuration for seeding Users in Database
    /// </summary>
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(CreateUsers());
        }

        private List<AppUser> CreateUsers()
        {
            var users = new List<AppUser>();
            var hasher = new PasswordHasher<AppUser>();

            var user = new AppUser()
            {
                Id = "737b8ae9-fff1-41e0-bb81-7ed16a44f1c2",
                UserName = "teacher@mail.com",
                NormalizedUserName = "teacher@mail.com",
                Email = "teacher@mail.com",
                NormalizedEmail = "teacher@mail.com",
                FirstName = "Kristiana",
                LastName = "Bakalova"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "teacher123");

            users.Add(user);

            user = new AppUser()
            {
                Id = "8175b008 - d14c - 4214 - 9e7e - 8dc0bdfa6b0c",
                UserName = "user@mail.com",
                NormalizedUserName = "user@mail.com",
                Email = "user@mail.com",
                NormalizedEmail = "user@mail.com",
                FirstName = "Maria",
                LastName = "Petrova"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "user123");

            users.Add(user);

            

            return users;
        }

    }
}
