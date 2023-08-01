using System.Collections.Generic;
using System.Linq;
using GestaoOvos.Data;
using GestaoOvos.Models;

namespace GestaoOvos.Services
{
    public class StatusPgtoService
    {
        private readonly GestaoOvosContext context;
        public StatusPgtoService(GestaoOvosContext context)
        {
            this.context = context;
        }

        public List<StatusPgto> StatusPagamentos()
        {
            return context.StatusPgto.ToList();
            
        }
    }
}
