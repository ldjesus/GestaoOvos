using GestaoOvos.Data;
using GestaoOvos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoOvos.Services
{
    public class QuantidadeService
    {
        private readonly Data.GestaoOvosContext context;

        public QuantidadeService(GestaoOvosContext context)
        {
            this.context = context;
        }

        public List<Quantidade> Quantidades()
        {
            return context.Quantidade.ToList();
        }
    }
}
