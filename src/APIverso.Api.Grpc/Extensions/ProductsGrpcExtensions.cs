using APIverso.Application.Dtos;
using APIverso.Domain.Models;
using APIverso.Grpc.Products;
using Grpc.Core;

namespace APIverso.Api.Grpc.Extensions
{
    public static class ProductsGrpcExtensions
    {
        public static ProductsListResponse ToProductsListResponse(this IEnumerable<Product> products)
        {
            IEnumerable<ProductGrpc> productsGrpc = products.Select(p => new ProductGrpc()
            {
                Id = p.Id.ToString(),
                Description = p.Description,
                Price = (double)p.Price
            });
            ProductsListResponse productsResponse = new();
            productsResponse.ProductsGrpc.AddRange(productsGrpc);
            return productsResponse;
        }

        public static ProductResponse ToProductResponse(this Product product)
        {
            return new ProductResponse()
            {
                ProductGrpc = new ProductGrpc()
                {
                    Id = product.Id.ToString(),
                    Description = product.Description,
                    Price = (double)product.Price
                }
            };
        }
        
        public static ProductDto ToProductDto(this CreateProductRequest createProductRequest)
        {
            return new ProductDto(createProductRequest.ProductDtoGrpc.Description, (decimal)createProductRequest.ProductDtoGrpc.Price);
        }

        public static Product ToProduct(this UpdateProductRequest updateProductRequest)
        {
            if (!Guid.TryParse(updateProductRequest.ProductGrpc.Id, out var id))
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Id inválido"));

            return new Product(id, updateProductRequest.ProductGrpc.Description, (decimal)updateProductRequest.ProductGrpc.Price);
        }

        public static Guid ToGuid(this DeleteProductRequest deleteProductRequest)
        {
            if (!Guid.TryParse(deleteProductRequest.Id, out var id))
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Id inválido"));

            return id;
        }

        public static Guid ToGuid(this GetByIdRequest getByIdRequest)
        {
            if (!Guid.TryParse(getByIdRequest.Id, out var id))
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Id inválido"));

            return id;
        }
    }
}
