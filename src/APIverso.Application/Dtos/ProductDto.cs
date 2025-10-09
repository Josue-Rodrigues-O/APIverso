namespace APIverso.Application.Dtos
{
    public class ProductDto(string descricao, decimal preco)
    {
        public string Descricao { get; set; } = descricao ?? string.Empty;
        public decimal Preco { get; set; } = preco;
    }
}
