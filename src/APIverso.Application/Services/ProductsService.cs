using APIverso.Application.Dtos;
using APIverso.Application.Mappings;
using APIverso.Domain.Interfaces;
using APIverso.Domain.Models;

namespace APIverso.Application.Services
{
    public class ProductsService(IProductsRepository productsRepository)
    {
        public IEnumerable<Product> GetAll()
        {
            return productsRepository.GetAll();
        }

        public Product GetById(Guid id)
        {
            return productsRepository.GetById(id);
        }

        public Product Create(ProductDto produtoDto)
        {
            return productsRepository.Create(produtoDto.ToProduct());
        }

        public void Update(Product updatedProduct)
        {
            productsRepository.Update(updatedProduct);
        }

        public void Delete(Guid id)
        {
            productsRepository.Delete(id);
        }
    }
}
