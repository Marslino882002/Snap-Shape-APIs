using Snap.Core.Repositories;
using Snap.Service.Repositories;

namespace Snap.APIs.Extensions
{
    public static class AiModelServicesExtension
    {
        public static IServiceCollection AddAiModelServices(this IServiceCollection services)
        {
            // HttpClient for calling the external Python AI service
            services.AddHttpClient();

            // Register the AI model service
            services.AddScoped<IAiModelService, AiModelService>();

            return services;
        }
    }
}
