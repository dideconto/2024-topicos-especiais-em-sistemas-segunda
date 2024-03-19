var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<Produto> produtos = new List<Produto>()
{
    new Produto("Celular", "Android"),
    new Produto("Celular", "IOS"),
    new Produto("Televisão", "LG"),
    new Produto("Cafeteira", "Oaster")
};


//End Points = Funcionalidades - JSON

// Exercício - Cadastrar um produto na lista de produtos
app.MapPost("/api/produto", () => "Minha primeira API com watch!");

app.MapGet("/api/produto", () => produtos);

app.Run();

public record Produto(string Nome, string Descricao);
