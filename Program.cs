using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.DB;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContexto>(Options =>
{
    Options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});


var app = builder.Build();



app.MapGet("/", () => "Olá Pessoal");

app.MapPost("/login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
    {
        return Results.Ok("Login com sucesso");

    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();