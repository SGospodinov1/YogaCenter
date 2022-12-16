using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YogaCenter.Infrastructure.Data.Configuration;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Infrastructure.Data
{
    /// <summary>
    /// Db Context
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {

        /// <summary>
        /// Parameter which defines whether the database should be seeded or not
        /// </summary>
        private bool seedDb;

        /// <summary>
        /// In constructor an If statement check if DB is Relational (MSSQL) or not (InMemoryDB) 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="seed"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, bool seed = true)
            : base(options)
        {

            if (this.Database.IsRelational())
            {
                this.Database.Migrate();
            }
            else
            {
                this.Database.EnsureCreated();
            }


            this.seedDb = seed;
        }

        /// <summary>
        /// DbSet for YogaClass
        /// </summary>
        public DbSet<YogaClass> YogaClasses { get; set; }

        /// <summary>
        /// DbSet for Teacher
        /// </summary>
        public DbSet<Teacher> Teachers { get; set; }

        /// <summary>
        /// DbSet for Comment
        /// </summary>
        public DbSet<Comment> Comments { get; set; }

        /// <summary>
        /// DbSet for Category
        /// </summary>
        public  DbSet<Category> Category { get; set; }

        /// <summary>
        /// DbSet for Post
        /// </summary>
        public DbSet<Post> Posts { get; set; }
        

        /// <summary>
        /// Configure DB Context
        /// </summary>
        /// <param name="builder"></param>
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
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>()
                .HasOne(u => u.AppUser)
                .WithMany(c => c.Comments)
                .HasForeignKey(u => u.AppUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


            if (this.seedDb)
            {
                builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });

                builder.ApplyConfiguration(new CategoryConfiguration());
                builder.ApplyConfiguration(new TeacherConfiguration());
                builder.ApplyConfiguration(new AppUserConfiguration());
                builder.ApplyConfiguration(new YogaClassConfiguration());
                builder.ApplyConfiguration(new PostConfiguration());
                builder.ApplyConfiguration(new CommentConfiguration());

            }



            base.OnModelCreating(builder);
        }
    }
}