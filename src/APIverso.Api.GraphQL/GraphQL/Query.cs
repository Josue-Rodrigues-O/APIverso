using APIverso.Application.Services;
using APIverso.Domain.Exceptions;
using APIverso.Domain.Models;

namespace APIverso.Api.GraphQL.GraphQL
{
    public class Query(ProductsService productsService)
    {
        public IEnumerable<Product> GetAll()
        {
            var result = productsService.GetAll();
            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            return result.Success!;
        }

        public Product GetById(Guid id)
        {
            var result = productsService.GetById(id);
            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            return result.Success!;
        }
    }
}