using APIverso.Application.Dtos;
using APIverso.Application.Services;
using APIverso.Domain.Exceptions;
using APIverso.Domain.Models;

namespace APIverso.Api.GraphQL.GraphQL
{
    public class Mutation
    {
        public Product Create(ProductDto productDto, [Service] ProductsService productsService)
        {
            var result = productsService.Create(productDto);
            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            return result.Success!;
        }

        public Product Update(Product product, [Service] ProductsService productsService)
        {
            var result = productsService.Update(product);
            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            return result.Success!;
        }

        public Product Delete(Guid id, [Service] ProductsService productsService)
        {
            var result = productsService.Delete(id);
            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            return result.Success!;
        }
    }
}