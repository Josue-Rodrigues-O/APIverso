using Domain.Interfaces;
using Domain.models;
using Infra.Dtos;

namespace Infra.Services;

public class ProdutosService(IProdutosRepository repository)
{
    public IEnumerable<Produto> GetAll()
    {
        return repository.GetAll();
    }

    public Produto? GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public Produto Add(ProdutoDto dto)
    {
        var produto = dto.ConverterParaProduto();
        return repository.Add(produto);
    }

    public void Update(Guid id, ProdutoDto dto)
    {
        var produto = dto.ConverterParaProduto();
        repository.Update(id, produto);
    }

    public void DeleteById(Guid id)
    {
        repository.DeleteById(id);
    }
}
