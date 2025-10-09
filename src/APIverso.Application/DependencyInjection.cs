using APIverso.Domain.Interfaces;
using APIverso.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace APIverso.Api.Rest
{
    public static class DependencyInjection
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductsRepository, ProductsRepositorySingleton>();
        }
    }
}
