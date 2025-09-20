using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MINIMAL_API.Dominio.Entidades;
using MINIMAL_API.Dominio.Interfaces;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.DB;

namespace MINIMAL_API.Dominio.Servicos;

public class AdministradorServico : iAdministradorServico
{
    private readonly DbContexto _contexto;
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;

    }
    public Administrador Login(LoginDTO loginDTO)
    {
        var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
        return adm;
    }
}