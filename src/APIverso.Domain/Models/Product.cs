namespace APIverso.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Product(string descricao, decimal preco)
        {
            Id = Guid.NewGuid();
            Description = descricao;
            Price = preco;
        }

        public Product(Guid id, string descricao, decimal preco)
        {
            Id = id;
            Description = descricao;
            Price = preco;
        }
    }
}
