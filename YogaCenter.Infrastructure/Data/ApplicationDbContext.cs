using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YogaCenter.Infrastructure.Data.Configuration;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<YogaClass> YogaClasses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public  DbSet<Category> Category { get; set; }
        public DbSet<Post> Posts { get; set; }
        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserYogaClass>()
                .HasKey(k => new { k.UserId, k.YogaClassId });

            builder.Entity<UserYogaClass>()
                .HasOne(y => y.YogaClass)
                .WithMany(uy => uy.UsersYogaClasses)
                .HasForeignKey(y => y.YogaClassId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserYogaClass>()
                .HasOne(u => u.User)
                .WithMany(uy => uy.UsersYogaClasses)
                .HasForeignKey(u => u.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN"});

            //builder.ApplyConfiguration(new CategoryConfiguration());
            //builder.ApplyConfiguration(new TeacherConfiguration());
            //builder.ApplyConfiguration(new AppUserConfiguration());
            //builder.ApplyConfiguration(new YogaClassConfiguration());
            //builder.ApplyConfiguration(new UserConfiguration());


            base.OnModelCreating(builder);
        }
    }
}