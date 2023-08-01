using GestaoOvos.Data;
using GestaoOvos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoOvos.Services
{
    public class ClienteService
    {
        private readonly GestaoOvosContext context;

        public ClienteService(GestaoOvosContext context)
        {
            this.context = context;
        }

        public List<Cliente> ListarClientes()
        {
            return context.Cliente.ToList();
        }
    }
}
