using APIverso.Application.Dtos;
using APIverso.Domain.Models;

namespace APIverso.Application.Mappings
{
    internal static class ProductMapper
    {
        internal static Product ToProduct(this ProductDto productDto)
            => new(productDto.Descricao, productDto.Preco);
    }
}
