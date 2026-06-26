var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () =>
{
    return "API Bancária está rodando!";
 });

app.MapGet("/contas", () =>
{
    return "Lista de contas";
});

app.Run();