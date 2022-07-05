using System.ComponentModel.DataAnnotations;
using ProjetoWebApi.Entities;

namespace ProjetoWebApi.Produtos.Request;

public class ProdutoAdicionarRequest
{
    [StringLength(200)]
    public string Nome { get; set; }
    [StringLength(2000)]
    public string? Descricao { get; set; }
    [Range(0,int.MaxValue)]
    public int Valor { get; set; }

    public static Produto Mapper(ProdutoAdicionarRequest pRequest)
    {
        return new Produto
        {
            Nome = pRequest.Nome,
            Descricao = pRequest.Descricao,
            Valor = pRequest.Valor
        };
    }
}