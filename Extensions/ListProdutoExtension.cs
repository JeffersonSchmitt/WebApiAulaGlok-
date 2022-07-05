using ProjetoWebApi.Entities;
using ProjetoWebApi.Produtos.Request;
using ProjetoWebApi.Produtos.Response;

namespace ProjetoWebApi.Extensions;

public static class ListProdutoExtension
{
    public static bool Remover(this List<Produto> pProdutos
        , int pId)
    {
        var xProduto = pProdutos.FirstOrDefault(p => p.Id == pId);

        if (xProduto is null)
            return false;

        pProdutos.Remove(xProduto);
        return true;
    }

    public static bool Alterar(this List<Produto> pProdutos, int pId, ProdutoAtualizarResquest pRequest)
    {
        var produto = pProdutos.FirstOrDefault(p => p.Id == pId);
        
        if (produto is null)
            return false;
        
        produto.Descricao = pRequest.Descricao;
        produto.Nome = pRequest.Nome;
        produto.Valor = pRequest.Valor;
        
        return true;
    }

}