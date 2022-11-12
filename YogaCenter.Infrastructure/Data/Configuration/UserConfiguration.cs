using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(CreateUsers());
        }

        private List<User> CreateUsers()
        {
            var users = new List<User>();
            var hasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = "737b8ae9-fff1-41e0-bb81-7ed16a44f1c2",
                UserName = "KristianaBakalova",
                NormalizedUserName = "KristianaBakalova",
                Email = "teacher@mail.com",
                NormalizedEmail = "teacher@mail.com"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "teacher123");

            users.Add(user);

            user = new User()
            {
                Id = "8175b008 - d14c - 4214 - 9e7e - 8dc0bdfa6b0c",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "guest123");

            users.Add(user);

            user = new User()
            {
                Id = "f01035fc-9c12-4f86-a01a-5fe5ce4d5dd2",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com"
            };

            user.PasswordHash =
                hasher.HashPassword(user, "admin123");

            users.Add(user);

            return users;
        }

    }
}
