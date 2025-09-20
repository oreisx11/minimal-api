using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MINIMAL_API.Dominio.Interfaces;
using MINIMAL_API.Dominio.Servicos;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<iAdministradorServico, AdministradorServico>();

builder.Services.AddDbContext<DbContexto>(Options =>
{
    Options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});


var app = builder.Build();



app.MapGet("/", () => "Olá Pessoal");

app.MapPost("/login", ([FromBody]LoginDTO loginDTO, AdministradorServico administradorServico) =>
{
    if (administradorServico.Login(loginDTO) != null)
    {
        return Results.Ok("Login com sucesso");

    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();