using APIverso.Application.Dtos;
using APIverso.Application.Services;
using APIverso.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIverso.Api.Rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(ProductsService productsService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(productsService.GetAll());
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok(productsService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDto productDto)
        {
            Product product = productsService.Create(productDto);
            return Created(product.Id.ToString(), product);
        }

        [HttpPut]
        public IActionResult GetUpdate([FromBody] Product updatedProduct)
        {
            productsService.Update(updatedProduct);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            productsService.Delete(id);
            return NoContent();
        }
    }
}
