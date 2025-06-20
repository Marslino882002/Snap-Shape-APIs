using Snap.Core.Repositories;
using Snap.Service.Repositories;

namespace Snap.APIs.Extensions
{
    public static class FoodDetectionServiceExtension
    {





        public static IServiceCollection AddFoodDetectionServices(this IServiceCollection services)
        {
            // Register Email Service
            //services.AddScoped<IFoodDetectionService, FoodDetectionService>();

            return services;
        }









    }
}







