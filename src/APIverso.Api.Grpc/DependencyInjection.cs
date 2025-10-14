using APIverso.Application;
using APIverso.Application.Services;

namespace APIverso.Api.Grpc
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.ConfigureApplicationServices();
            services.AddScoped<ProductsService>();
            return services;
        }
    }
}
