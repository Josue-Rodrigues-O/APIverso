using APIverso.Api.Grpc.Extensions;
using APIverso.Application.Services;
using APIverso.Grpc.Products;
using Grpc.Core;

namespace APIverso.Api.Grpc.Services
{
    public class ProductsGrpcServiceImpl(ProductsService productsService) : ProductsGrpcService.ProductsGrpcServiceBase
    {
        public override Task<ProductsListResponse> GetAll(Empty request, ServerCallContext context)
        {
            var products = productsService.GetAll().ToProductsListResponse();
            return Task.FromResult(products);
        }

        public override Task<ProductResponse> GetById(GetByIdRequest request, ServerCallContext context)
        {
            var id = request.ToGuid();
            var product = productsService.GetById(id) ??
                throw new RpcException(new Status(StatusCode.NotFound, "Produto não encontrado"));

            return Task.FromResult(product.ToProductResponse());
        }

        public override Task<ProductResponse> Create(CreateProductRequest request, ServerCallContext context)
        {
            var product = productsService.Create(request.ToProductDto());
            return Task.FromResult(product.ToProductResponse());
        }

        public override Task<Empty> Update(UpdateProductRequest request, ServerCallContext context)
        {
            productsService.Update(request.ToProduct());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> Delete(DeleteProductRequest request, ServerCallContext context)
        {
            var id = request.ToGuid();
            productsService.Delete(id);
            return Task.FromResult(new Empty());
        }
    }
}
