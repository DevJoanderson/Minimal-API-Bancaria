using ApiBancaria.Models;
using ApiBancaria.Requests;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
List<Conta> contas = new();

app.MapGet("/", () =>
{
    return "API Bancária está rodando!";
 });

app.MapGet("/contas", () =>
{
    return contas;
});

app.MapPost("/contas", (Conta conta) =>
{
    conta.Id = contas.Count + 1;

    contas.Add(conta);

    return Results.Created($"/contas/{conta.Id}", conta);
});

app.MapGet("/contas/{id}", (int id) => {
    Conta? conta = contas.FirstOrDefault(conta => conta.Id == id);

    if (conta == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(conta);
});

app.MapPost("/contas/{id}/depositar", (int id, [FromBody] DepositoRequest request) =>
{
    Conta? conta = contas.FirstOrDefault(conta => conta.Id == id);

    if (conta == null)
    {
        return Results.NotFound();
    }

    conta.Depositar(request.Valor);

    return Results.Ok(conta);
});

app.Run();  