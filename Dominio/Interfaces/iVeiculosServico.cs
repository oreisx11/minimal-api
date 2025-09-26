using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MINIMAL_API.Dominio.Entidades;
using MinimalApi.DTOs;

namespace MINIMAL_API.Dominio.Interfaces
{
    public interface iVeiculoServico
    {
        List<Veiculo> Todos(int pagina = 1, string? nome = null, string? marca = null);

        Veiculo BuscaPorId(int id);
        void Incluir(Veiculo veiculo);
        void Atualizar(Veiculo veiculo);
        void Apagar(Veiculo veiculo);
    }
}