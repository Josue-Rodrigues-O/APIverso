using APIverso.Api.GraphQL.FilterActions;
using APIverso.Api.GraphQL.GraphQL;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;

namespace APIverso.Api.GraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConfigureServices();
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddErrorFilter<GraphQLErrorFilter>();

            var app = builder.Build();

            app.MapGraphQL();
            app.UsePlayground(new PlaygroundOptions
            {
                QueryPath = "/graphql",
                Path = "/playground"
            });

            app.Run();
        }
    }
}
