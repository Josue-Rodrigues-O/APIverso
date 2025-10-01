using Infra.Dtos;
using Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace Rest.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController(ProdutosService produtosService) : ControllerBase
{
    [HttpGet]
    public OkObjectResult GetAll()
    {
        return Ok(produtosService.GetAll());
    }

    [HttpGet("{id:guid}")]
    public OkObjectResult GetById([FromRoute] Guid id)
    {
        return Ok(produtosService.GetById(id));
    }

    [HttpPost]
    public CreatedResult Add([FromBody] ProdutoDto dto)
    {
        var novoProduto = produtosService.Add(dto);
        return Created(novoProduto.Id.ToString(), novoProduto);
    }

    [HttpPut("{id:guid}")]
    public NoContentResult Update([FromRoute] Guid id, [FromBody] ProdutoDto dto)
    {
        produtosService.Update(id, dto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public NoContentResult DeleteById([FromRoute] Guid id)
    {
        produtosService.DeleteById(id);
        return NoContent();
    }
}
