using APIverso.Domain.Models;

namespace APIverso.Domain.Interfaces
{
    public interface IProductsRepository
    {
        /// <summary>
        /// Retornar lista com todos os produtos salvos.
        /// </summary>
        /// <returns></returns>
        Result<IEnumerable<Product>> GetAll();
        /// <summary>
        /// Retornar o produto com id correspondente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Result<Product> GetById(Guid id);
        /// <summary>
        /// Retorna o produto criado em caso de sucesso.
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        Result<Product> Create(Product produto);
        /// <summary>
        /// Retorna o produto atualizado em caso de sucesso.
        /// </summary>
        /// <param name="produtoAtualizado"></param>
        /// <returns></returns>
        Result<Product> Update(Product produtoAtualizado);
        /// <summary>
        /// Retorna o produto removido em caso de sucesso.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Result<Product> Delete(Guid id);
    }
}
