using APIverso.Application.Dtos;
using APIverso.Application.Services;
using APIverso.Domain.Exceptions;
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
            var result = productsService.GetAll();

            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            return Ok(result.Success);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = productsService.GetById(id);

            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            return Ok(result.Success);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDto productDto)
        {
            var result = productsService.Create(productDto);

            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            return Created(result.Success!.Id.ToString(), result.Success);
        }

        [HttpPut]
        public IActionResult GetUpdate([FromBody] Product updatedProduct)
        {
            var result = productsService.Update(updatedProduct);

            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            return Ok(result.Success);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var result = productsService.Delete(id);

            if (result.IsFailure)
                throw new DomainFailureException(result.Failure!);

            return Ok(result.Success);
        }
    }
}
