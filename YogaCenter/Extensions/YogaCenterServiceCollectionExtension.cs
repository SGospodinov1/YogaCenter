using YogaCenter.Infrastructure.Data.Common;

namespace YogaCenter.Extensions
{
    public static class YogaCenterServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();


            return services;
        }

    }
}
