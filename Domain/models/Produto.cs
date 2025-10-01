namespace Domain.models;

public class Produto(string nome, decimal preco)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = nome;
    public decimal Preco { get; set; } = preco;
}
