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

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product? GetById(Guid id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Product Create(Product produto)
        {
            _products.Add(produto);
            return produto;
        }

        public void Update(Product produtoAtualizado)
        {
            int index = _products.FindIndex(p => p.Id == produtoAtualizado.Id);
            if (index != -1)
                _products[index] = produtoAtualizado;
        }

        public void Delete(Guid id)
        {
            Product? product = GetById(id);
            if (product != null)
                _products.Remove(product);
        }
    }
}
