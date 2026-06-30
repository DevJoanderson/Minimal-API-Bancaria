using ApiBancaria.Models;

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

app.Run();  