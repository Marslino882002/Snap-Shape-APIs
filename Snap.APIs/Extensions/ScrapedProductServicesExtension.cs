using Snap.Core.Repositories;
using Snap.Core.ScrapedProducts.Commands.ScrapeHealthyProducts;
using Snap.Core.ScrapedProducts;
using Snap.Service.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Snap.Core.ScrapedProducts.Queries;

namespace Snap.APIs.Extensions
{
    public static class ScrapedProductServicesExtension
    {
        public static IServiceCollection AddScrapedProductServices(this IServiceCollection services)
        {
            // Register HTTP client for scraping
            services.AddHttpClient();

            // Register repository implementation
            services.AddScoped<IScrapedProductRepository, ScrapedProductRepository>();

            // Register MediatR handlers in the Service assembly
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ScrapeHealthyProductsCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetScrapedProductsQueryHandler).Assembly);
            });

            // AutoMapper profiles
            services.AddAutoMapper(cfg =>
                cfg.AddProfile<ScrapedProductProfile>()
            );

            return services;
        }
    }
}
