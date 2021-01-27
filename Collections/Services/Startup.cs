using Microsoft.Extensions.DependencyInjection;
using Services.Abstractions.Interfaces;
using Services.Impl;

namespace Services
{
    public static class Startup
    {
        public static IServiceCollection AddServices(this IServiceCollection services) =>
            services.AddScoped<ICollectionService, CollectionService>();
    }
}
