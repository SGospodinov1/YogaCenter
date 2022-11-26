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
        public DbSet<Comment> Comments { get; set; }
        public  DbSet<Category> Category { get; set; }
        public DbSet<Post> Posts { get; set; }
        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUserYogaClass>()
                .HasKey(k => new { k.AppUserId, k.YogaClassId });

            builder.Entity<AppUserYogaClass>()
                .HasOne(y => y.YogaClass)
                .WithMany(uy => uy.AppUsersYogaClasses)
                .HasForeignKey(y => y.YogaClassId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppUserYogaClass>()
                .HasOne(u => u.AppUser)
                .WithMany(uy => uy.AppUsersYogaClasses)
                .HasForeignKey(u => u.AppUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(u => u.YogaClass)
                .WithMany(c => c.Comments)
                .HasForeignKey(u => u.YogaClassId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(u => u.AppUser)
                .WithMany(c => c.Comments)
                .HasForeignKey(u => u.AppUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });

            //builder.ApplyConfiguration(new CategoryConfiguration());
            //builder.ApplyConfiguration(new TeacherConfiguration());
            //builder.ApplyConfiguration(new AppUserConfiguration());
            //builder.ApplyConfiguration(new YogaClassConfiguration());



            base.OnModelCreating(builder);
        }
    }
}