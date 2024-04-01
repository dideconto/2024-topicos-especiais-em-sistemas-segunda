using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> produtos = new List<Produto>();

// Endpoints = Funcionalidades - JSON
// POST: http://localhost:5076/api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto) =>
{
    //Adicionando o produto dentro da lista
    produtos.Add(produto);
    return Results.Created("", produto);
});

// GET: http://localhost:5076/api/produto/listar
app.MapGet("/api/produto/listar", () => produtos);

// GET: http://localhost:5076/api/produto/buscar/{nomedoproduto}
app.MapGet("/api/produto/buscar/{nome}", ([FromRoute] string nome) =>
{
    //Endpoint com várias linhas de código
    for (int i = 0; i < produtos.Count; i++)
    {
        if (produtos[i].Nome == nome)
        {
            return Results.Ok(produtos[i]);
        }
    }
    return Results.NotFound("Produto não encontrado!");
});

app.Run();