using System.Security.Cryptography.X509Certificates;

namespace APIverso.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Product()
        {
            Id = Guid.Empty;
            Description = string.Empty;
            Price = decimal.Zero;
        }
        
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
