using APIverso.Application.Services;

namespace APIverso.Api.Rest
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
