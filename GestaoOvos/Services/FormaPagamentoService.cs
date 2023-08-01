using GestaoOvos.Data;
using GestaoOvos.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestaoOvos.Services
{
    public class FormaPagamentoService
    {
        private readonly GestaoOvosContext context;
        public FormaPagamentoService(GestaoOvosContext context)
        {
            this.context = context;
        }

        public List<FormaPagamento> FormaPagamento()
        {
            return context.FormaPagamento.ToList();
        }
    }
}
