namespace API.Models;
public class Produto
{
    public Produto()
    {
        CriadoEm = DateTime.Now;
        Id = Guid.NewGuid().ToString();
    }

    public Produto(string nome, string descricao, double preco)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        CriadoEm = DateTime.Now;
        Id = Guid.NewGuid().ToString();
    }

    //Atributo ou propriedade - nome e descricao
    public string? Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }
    public DateTime CriadoEm { get; set; }

}
