using Domain.Interfaces;
using Domain.models;

namespace Infra.Repositories;

public class ProdutosRepositorySingleton : IProdutosRepository
{
    private readonly List<Produto> _produtos =
    [
        new("Café", 15.50M),
        new("Paçoca", 1.25M),
        new("Macarrão", 4.20M),
        new("Milho", 5.00M),
    ];

    public IEnumerable<Produto> GetAll()
    {
        return _produtos;
    }

    public Produto? GetById(Guid id)
    {
        return _produtos.FirstOrDefault(p => p.Id == id);
    }

    public Produto Add(Produto produto)
    {
        _produtos.Add(produto);
        return produto;
    }

    public void Update(Guid id, Produto produtoAtualizado)
    {
        var produto = GetById(id);
        if (produto is not null)
        {
            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;
            var index = _produtos.FindIndex(p => p.Id == id);
            _produtos[index] = produto;
        }
    }

    public void DeleteById(Guid id)
    {
        var produto = GetById(id);

        if (produto is not null)
            _produtos.Remove(produto);
    }
}