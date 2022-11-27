using YogaCenter.Infrastructure.Data.Common;
using YogaCenter.Core;
using YogaCenter.Core.Contracts;
using YogaCenter.Core.Services;

namespace YogaCenter.Extensions
{
    public static class YogaCenterServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IYogaClassService, YogaClassService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ICommentService, CommentService>();


            return services;
        }

    }
}
