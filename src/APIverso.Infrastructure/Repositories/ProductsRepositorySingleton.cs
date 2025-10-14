using APIverso.Domain.Enums;
using APIverso.Domain.Interfaces;
using APIverso.Domain.Models;

namespace APIverso.Infrastructure.Repositories
{
    public class ProductsRepositorySingleton : IProductsRepository
    {
        private readonly List<Product> _products = new List<Product>()
        {
            new("Abacaxi", 8.68M),
            new("Tomate", 4.55M),
            new("Manga", 7.99M),
        };

        public Result<IEnumerable<Product>> GetAll()
        {
            return Result<IEnumerable<Product>>.AsSuccess(_products);
        }

        public Result<Product> GetById(Guid id)
        {
            Product? product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return Result<Product>.AsFailure(new($"Produto com id [{id}] não foi encontrado.", FailureTypeEnum.NOT_FOUND));

            return Result<Product>.AsSuccess(product);
        }

        public Result<Product> Create(Product product)
        {
            _products.Add(product);
            return Result<Product>.AsSuccess(product);
        }

        public Result<Product> Update(Product updatedProduct)
        {
            int index = _products.FindIndex(p => p.Id == updatedProduct.Id);
            if (index == -1)
                return Result<Product>.AsFailure(new($"Produto com id [{updatedProduct.Id}] não foi encontrado.", FailureTypeEnum.NOT_FOUND));

            _products[index] = updatedProduct;
            return Result<Product>.AsSuccess(_products[index]);
        }

        public Result<Product> Delete(Guid id)
        {
            return GetById(id).Bind(product =>
            {
                _products.Remove(product);
                return Result<Product>.AsSuccess(product);
            });
        }
    }
}
