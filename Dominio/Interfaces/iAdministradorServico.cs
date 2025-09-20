using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MINIMAL_API.Dominio.Entidades;
using MinimalApi.DTOs;

namespace MINIMAL_API.Dominio.Interfaces
{
    public interface iAdministradorServico
    {
        Administrador? Login(LoginDTO loginDTO);
    }
}