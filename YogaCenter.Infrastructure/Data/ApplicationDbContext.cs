using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<YogaClass> YogaClasses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public  DbSet<Category> Category { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserYogaClass> UsersYogaClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserYogaClass>()
                .HasKey(k => new { k.UserId, k.YogaClassId });

            base.OnModelCreating(builder);
        }
    }
}