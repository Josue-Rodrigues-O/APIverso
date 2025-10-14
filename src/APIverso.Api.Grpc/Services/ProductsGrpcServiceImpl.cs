using APIverso.Api.Grpc.Extensions;
using APIverso.Application.Services;
using APIverso.Domain.Exceptions;
using APIverso.Grpc.Products;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace APIverso.Api.Grpc.Services
{
    public class ProductsGrpcServiceImpl(ProductsService productsService) : ProductsGrpcService.ProductsGrpcServiceBase
    {
        public override Task<ProductsListResponse> GetAll(Empty request, ServerCallContext context)
        {
            var result = productsService.GetAll();

            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            var products = result.Success!.ToProductsListResponse();
            return Task.FromResult(products);
        }

        public override Task<ProductResponse> GetById(GetByIdRequest request, ServerCallContext context)
        {
            var id = request.ToGuid();
            var result = productsService.GetById(id);

            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            var product = result.Success!.ToProductResponse();
            return Task.FromResult(product);
        }

        public override Task<ProductResponse> Create(CreateProductRequest request, ServerCallContext context)
        {
            var result = productsService.Create(request.ToProductDto());

            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            var product = result.Success!.ToProductResponse();
            return Task.FromResult(product);
        }

        public override Task<ProductResponse> Update(UpdateProductRequest request, ServerCallContext context)
        {
            var result = productsService.Update(request.ToProduct());

            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            var product = result.Success!.ToProductResponse();
            return Task.FromResult(product);
        }

        public override Task<ProductResponse> Delete(DeleteProductRequest request, ServerCallContext context)
        {
            var id = request.ToGuid();
            var result = productsService.Delete(id);

            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            var product = result.Success!.ToProductResponse();
            return Task.FromResult(product);
        }
    }
}
