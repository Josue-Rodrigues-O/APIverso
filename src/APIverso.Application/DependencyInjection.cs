using APIverso.Domain.Interfaces;
using APIverso.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace APIverso.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductsRepository, ProductsRepositorySingleton>();
            return services;
        }
    }
}
