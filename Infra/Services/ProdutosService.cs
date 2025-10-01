using Domain.models;
using Infra.Dtos;

namespace Infra.Services;

public class ProdutosService
{
    private readonly List<Produto> _produtos =
    [
        new("Café",15.50M),
        new("Paçoca",1.25M),
        new("Macarrão",4.20M),
        new("Milho",5.00M),
    ];

    public IEnumerable<Produto> GetAll()
    {
        return _produtos;
    }

    public Produto? GetById(Guid id)
    {
        return _produtos.FirstOrDefault(p => p.Id == id);
    }

    public Produto Add(ProdutoDto dto)
    {
        var produto = dto.ConverterParaProduto();
        _produtos.Add(produto);
        return produto;
    }

    public void Update(Guid id, ProdutoDto dto)
    {
        var produto = GetById(id);
        if (produto is not null)
        {
            produto.Nome = dto.Nome;
            produto.Preco = dto.Preco;
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
