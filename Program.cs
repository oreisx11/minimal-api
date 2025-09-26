using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MINIMAL_API.Dominio.DTOs;
using MINIMAL_API.Dominio.Entidades;
using MINIMAL_API.Dominio.Interfaces;
using MINIMAL_API.Dominio.ModelViews;
using MINIMAL_API.Dominio.Servicos;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.DB;

#region builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<iAdministradorServico, AdministradorServico>();
builder.Services.AddScoped<iVeiculoServico, VeiculoServico>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContexto>(Options =>
{
    Options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});
#endregion

#region Home
var app = builder.Build();
app.MapGet("/", () => Results.Json(new Home()));
#endregion

#region Administradores-
app.MapPost("/Administradores/login", ([FromBody] LoginDTO loginDTO, AdministradorServico administradorServico) =>
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
#endregion

#region Veiculos
app.MapPost("/veiculos", ([FromBody] VeiculoDTO VeiculoDTO, iVeiculoServico VeiculoServico) =>
{
    var veiculo = new Veiculo
    {
        Nome = VeiculoDTO.Nome,
        Marca = VeiculoDTO.Marca,
        Ano = VeiculoDTO.Ano
    };
    VeiculoServico.Incluir(veiculo);
    return Results.Created($"/veiculo/{veiculo.Id}", veiculo);

});
#endregion

#region app
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
#endregion