using APIverso.Application;
using APIverso.Application.Services;

namespace APIverso.Api.GraphQL
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.ConfigureApplicationServices();
            services.AddScoped<ProductsService>();
        }
    }
}
