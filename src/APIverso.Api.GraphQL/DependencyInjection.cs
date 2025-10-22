using APIverso.Api.GraphQL.ActionsFilter;
using APIverso.Api.GraphQL.GraphQL;
using APIverso.Application;
using APIverso.Application.Dtos;
using APIverso.Application.Services;
using APIverso.Domain.Models;

namespace APIverso.Api.GraphQL
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.ConfigureApplicationServices();
            services.AddScoped<ProductsService>();
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<Product>()
                .AddType<ProductDto>()
                .AddErrorFilter<GraphQLErrorFilter>()
                .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);
        }
    }
}
