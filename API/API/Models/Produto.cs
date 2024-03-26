namespace API.Models;
public class Produto
{
    public Produto() { }

    public Produto(string nome, string descricao, double preco)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
    }
    //Atributo ou propriedade - nome e descricao
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public double Preco { get; set; }

}
