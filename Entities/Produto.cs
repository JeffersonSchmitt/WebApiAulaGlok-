namespace ProjetoWebApi.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public int Valor { get; set; }
}