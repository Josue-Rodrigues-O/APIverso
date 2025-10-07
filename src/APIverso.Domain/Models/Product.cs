namespace APIverso.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public Product(string descricao, decimal preco)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Preco = preco;
        }
    }
}
