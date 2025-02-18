using Snap.Core.Repositories;
using Snap.Service.Repositories;

namespace Snap.APIs.Extensions
{
    public static class AboutServicesExtension
    {


        public static IServiceCollection AddAboutServices(this IServiceCollection services)
        {
            // Register Email Service
            services.AddScoped<IAboutRepository, AboutRepository>();

            return services;
        }






    }
}
