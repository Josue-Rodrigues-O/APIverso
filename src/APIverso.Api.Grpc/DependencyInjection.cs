using APIverso.Api.Rest;
using APIverso.Application.Services;

namespace APIverso.Api.Grpc
{
    public static class DependencyInjection
    {
        public static void ConfigureRestServices(this IServiceCollection services)
        {
            services.ConfigureApplicationServices();
            services.AddScoped<ProductsService>();
        }
    }
}
