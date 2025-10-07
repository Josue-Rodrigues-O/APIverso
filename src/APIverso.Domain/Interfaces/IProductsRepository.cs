using APIverso.Domain.Models;

namespace APIverso.Domain.Interfaces
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(Guid id);
        Product Create(Product produto);
        void Update(Product produtoAtualizado);
        void Delete(Guid id);
    }
}
