using Domain.models;

namespace Domain.Interfaces;

public interface IProdutosRepository
{
   IEnumerable<Produto> GetAll();
   Produto? GetById(Guid id);
   Produto Add(Produto produto);
   void Update(Guid id, Produto produto);
   void DeleteById(Guid id);
}