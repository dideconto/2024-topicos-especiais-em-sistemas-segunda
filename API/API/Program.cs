using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> produtos =
[
    new Produto("Celular", "Android", 4500.5),
    new Produto("Celular", "IOS", 3000),
    new Produto("Televisão", "LG", 2000),
    new Produto("Cafeteira", "Oaster", 250)
];

// Cadastrar um produto na lista
// a) Através das informações na URL
// b) Através das informações no corpo da requisição
// Realizar as operações alteração e remoção da lista

// Endpoints = Funcionalidades - JSON
// POST: http://localhost:5076/api/produto/cadastrar
app.MapPost("/api/produto/cadastrar/",
    ([FromRoute] string nome, [FromRoute] string descricao) =>
{
    //Preenchendo o objeto pelo construtor
    Produto produto = new Produto(nome, descricao, 123);

    //Preenchendo o objeto pelo atributo
    produto.Nome = nome;
    produto.Descricao = descricao;

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