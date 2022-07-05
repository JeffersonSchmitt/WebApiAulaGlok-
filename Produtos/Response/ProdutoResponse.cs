using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using ProjetoWebApi.Entities;

namespace ProjetoWebApi.Produtos.Response;

public class ProdutoResponse
{
    public int Id { get; set; }
    
    [StringLength(200)]
    public string Nome { get; set; }
    [StringLength(2000)]
    public string? Descricao { get; set; }
    [Range(0,int.MaxValue)]
    public int Valor { get; set; }

    public static IEnumerable<ProdutoResponse> Mapper(IEnumerable<Produto> pItens)
    {
        return pItens.Select(Mapper);
    }
    public static ProdutoResponse Mapper(Produto pProduto)
    {
        return new ProdutoResponse
        {
            Id = pProduto.Id,
            Nome = pProduto.Nome,
            Descricao = pProduto.Descricao,
            Valor = pProduto.Valor
        };
    }
}