using GestaoOvos.Data;
using GestaoOvos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoOvos.Services
{
    public class StatusEntregaService
    {
        private readonly GestaoOvosContext context;
        public StatusEntregaService(GestaoOvosContext context)
        {
            this.context = context;
        }

        public List<StatusEntrega> StatusEntrega()
        {
            return context.StatusEntrega.ToList();
        }
    }

   
}
