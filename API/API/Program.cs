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
    return Results.Created($"/api/produto/buscar/{produto.Id}", produto);
});

// GET: http://localhost:5076/api/produto/listar
app.MapGet("/api/produto/listar", () => produtos);

// GET: http://localhost:5076/api/produto/buscar/{iddoproduto}
app.MapGet("/api/produto/buscar/{id}", ([FromRoute] string id) =>
{
    //Endpoint com várias linhas de código
    for (int i = 0; i < produtos.Count; i++)
    {
        if (produtos[i].Id == id)
        {
            return Results.Ok(produtos[i]);
        }
    }
    return Results.NotFound("Produto não encontrado!");
});

// DELETE: http://localhost:5076/api/produto/deletar/{iddoproduto}
app.MapDelete("/api/produto/deletar/{id}", ([FromRoute] string id) =>
{
    //Endpoint com várias linhas de código
    for (int i = 0; i < produtos.Count; i++)
    {
        if (produtos[i].Id == id)
        {
            produtos.Remove(produtos[i]);
            return Results.NoContent();
        }
    }
    return Results.NotFound("Produto não encontrado!");
});


// PUT: http://localhost:5076/api/produto/alterar/{iddoproduto}
app.MapPut("/api/produto/alterar/{id}", ([FromRoute] string id, [FromBody] Produto produtoAlterado) =>
{
    //Endpoint com várias linhas de código
    for (int i = 0; i < produtos.Count; i++)
    {
        if (produtos[i].Id == id)
        {
            produtos[i].Nome = produtoAlterado.Nome;
            produtos[i].Descricao = produtoAlterado.Descricao;
            produtos[i].Preco = produtoAlterado.Preco;
            return Results.Ok("Produto alterado com sucesso!");
        }
    }
    return Results.NotFound("Produto não encontrado!");
});

app.Run();

//CONFIGURAR O BANCO NA APLICAÇÃO
//1 - Quais as bibliotecas serão instaladas no projeto
//2 - O que é necessário adicionar/alterar no projeto
//para configurar a aplicação com o banco

//dotnet add package Microsoft.EntityFrameworkCore.Sqlite 
//--version 8.0.3
//dotnet add package Microsoft.EntityFrameworkCore.Design 
//--version 8.0.3 

//EXERÍCIOS PARA O EF
//1 - Cadastrar o objeto de produto no banco
//2 - Listar os registros da tabela