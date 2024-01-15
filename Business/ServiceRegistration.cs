using Business.Repository.Implementations;
using Business.Repository.Interfaces;
using Business.Services.Implementations;
using Business.Services.Interfaces;

namespace Business
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBlogService, BlogService>();
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBlogRepository,BlogRepository>();
        }

    }
}
