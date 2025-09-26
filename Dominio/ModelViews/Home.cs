using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MINIMAL_API.Dominio.ModelViews
{
    public struct Home
    {
        public string Mensagem { get => "/Bem vindo a API de veiculos"; }
        public string Doc { get => "/swagger"; }
    }
}