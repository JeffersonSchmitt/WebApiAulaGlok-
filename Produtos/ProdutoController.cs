using Microsoft.AspNetCore.Mvc;
using ProjetoWebApi.Entities;
using ProjetoWebApi.Extensions;
using ProjetoWebApi.Produtos.Request;
using ProjetoWebApi.Produtos.Response;

namespace ProjetoWebApi.Produtos;

[ApiController]
[Route("produtos")]
public class ProdutosController : ControllerBase
{
    private static readonly List<Produto> _produtos = new();
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<ProdutoResponse>> Get()
    {
        return Ok(ProdutoResponse.Mapper(_produtos));
    }

    [HttpGet("{pId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<ProdutoResponse>> Get(int pId)
    {
        var xProduto = _produtos.FirstOrDefault(p => p.Id == pId);
        return xProduto is null
            ? NotFound() 
            : Ok(xProduto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<ProdutoResponse>> Post([FromBody]ProdutoAdicionarRequest pRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var xRequest = ProdutoAdicionarRequest.Mapper(pRequest);
        
        _produtos.Add(xRequest);
        
        var xResponse = ProdutoResponse.Mapper(xRequest);
        
        return CreatedAtAction(nameof(Get), new { pId = xResponse.Id }, xResponse);
    }

    [HttpPut("{pId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<ProdutoResponse>> Put(int pId, [FromBody] ProdutoAtualizarResquest pRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var xAlterou = _produtos.Alterar(pId, pRequest);

        return xAlterou?NoContent():NotFound();
    }

    [HttpDelete("{pId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<ProdutoResponse>> Delete(int pId)
    {
        var xRemoveu = _produtos.Remover(pId);
        return xRemoveu ? NoContent() : NotFound();
    }
}