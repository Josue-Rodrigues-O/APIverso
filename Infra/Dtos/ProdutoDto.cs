using Domain.models;

namespace Infra.Dtos;

public class ProdutoDto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }

    public ProdutoDto()
    {
        Nome = "";
        Preco = 0M;
    }

    public ProdutoDto(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }

    public Produto ConverterParaProduto()
    {
        return new Produto(Nome, Preco);
    }
}