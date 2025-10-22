namespace APIverso.Api.GraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.ConfigureServices();
            var app = builder.Build();
            app.MapGraphQL("/graphql");
            app.Run();
        }
    }
}
