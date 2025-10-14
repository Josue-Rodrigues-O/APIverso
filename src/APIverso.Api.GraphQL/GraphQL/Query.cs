using APIverso.Application.Services;
using APIverso.Domain.Exceptions;
using APIverso.Domain.Models;

namespace APIverso.Api.GraphQL.GraphQL
{
    public class Query
    {
        public IEnumerable<Product> GetAll([Service] ProductsService productsService)
        {
            var result = productsService.GetAll();
            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            return result.Success!;
        }

        public Product GetById(Guid id, [Service] ProductsService productsService)
        {
            var result = productsService.GetById(id);
            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            return result.Success!;
        }
    }
}