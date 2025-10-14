using APIverso.Application.Dtos;
using APIverso.Application.Mappings;
using APIverso.Domain.Interfaces;
using APIverso.Domain.Models;

namespace APIverso.Application.Services
{
    public class ProductsService(IProductsRepository productsRepository)
    {
        public Result<IEnumerable<Product>> GetAll()
        {
            return productsRepository.GetAll();
        }

        public Result<Product> GetById(Guid id)
        {
            return productsRepository.GetById(id);
        }

        public Result<Product> Create(ProductDto produtoDto)
        {
            return productsRepository.Create(produtoDto.ToProduct());
        }

        public Result<Product> Update(Product updatedProduct)
        {
            return productsRepository.Update(updatedProduct);
        }

        public Result<Product> Delete(Guid id)
        {
            return productsRepository.Delete(id);
        }
    }
}
