using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProniaOnionAB104.Application.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(CategoryProfile));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
