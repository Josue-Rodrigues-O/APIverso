using APIverso.Application.Dtos;
using APIverso.Application.Services;
using APIverso.Domain.Exceptions;
using APIverso.Domain.Models;

namespace APIverso.Api.GraphQL.GraphQL
{
    public class Mutation(ProductsService productsService)
    {
        public Product Create(ProductDto productDto)
        {
            var result = productsService.Create(productDto);
            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            return result.Success!;
        }

        public Product Update(Product product)
        {
            var result = productsService.Update(product);
            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            return result.Success!;
        }

        public Product Delete(Guid id)
        {
            var result = productsService.Delete(id);
            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            return result.Success!;
        }
    }
}