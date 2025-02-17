using Microsoft.Extensions.DependencyInjection;
using Snap.Core.Repositories;
using Snap.Service;
using Snap.Service.Repositories;

namespace Snap.APIs.Extensions
{
    public static class MailServicesExtension
    {
        public static IServiceCollection AddMailServices(this IServiceCollection services)
        {
            // Register Email Service
            services.AddScoped<IEmailRepository, EmailRepository>();

            return services;
        }
    }
}
