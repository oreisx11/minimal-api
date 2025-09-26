using Microsoft.EntityFrameworkCore;

using MINIMAL_API.Dominio.Entidades;
using MINIMAL_API.Dominio.Interfaces;
using MinimalApi.Infraestrutura.DB;

namespace MINIMAL_API.Dominio.Servicos;

public class VeiculoServico(DbContexto contexto) : iVeiculoServico
{
    private readonly DbContexto _contexto = contexto;

    public void Apagar(Veiculo veiculo)
    {
        _contexto.Veiculos.Remove(veiculo);
        _contexto.SaveChanges();
    }  

    public void Atualizar(Veiculo veiculo)
    {
        _contexto.Veiculos.Update(veiculo);
        _contexto.SaveChanges();
    }

    public Veiculo? BuscaPorId(int id)
    {
        return _contexto.Veiculos.Where(v => v.Id == id).FirstOrDefault();
    }

    public void Incluir(Veiculo veiculo)
    {
        _contexto.Veiculos.Add(veiculo);
        _contexto.SaveChanges();
    }

    public List<Veiculo> Todos(int pagina = 1, string? nome = null, string? marca = null)
    {
        var query = _contexto.Veiculos.AsQueryable();
        if (!string.IsNullOrEmpty(nome))
        {
            query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"{nome.ToLower()}"));
        }
        int itensPorPagina = 10;


        query = query.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina);

        return query.ToList();
    }
}