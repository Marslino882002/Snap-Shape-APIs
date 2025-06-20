using Snap.Core.Repositories;
using Snap.Service.Repositories;

namespace Snap.APIs.Extensions
{
    public static class FoodDetectionV2ServicesExtension
    {

        public static IServiceCollection AddFoodDetectionServicesV2(this IServiceCollection services)
        {
            // Register Food Detection Service
            services.AddScoped<IFoodDetectionServiceV2, FoodDetectionServiceV2>();

            // Register HttpClient for the service (if you're using named clients, this can be enhanced)
            services.AddHttpClient<FoodDetectionServiceV2>();

            return services;
        }









    }
}
