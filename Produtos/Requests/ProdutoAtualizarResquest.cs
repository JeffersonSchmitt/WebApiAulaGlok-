using System.ComponentModel.DataAnnotations;
using ProjetoWebApi.Entities;

namespace ProjetoWebApi.Produtos.Request;

public class ProdutoAtualizarResquest
{
    [StringLength(200)]
    public string Nome { get; set; }
    [StringLength(2000)]
    public string? Descricao { get; set; }
    [Range(0,int.MaxValue)]
    public int Valor { get; set; }
    
}