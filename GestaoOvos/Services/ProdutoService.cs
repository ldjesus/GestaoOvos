using GestaoOvos.Data;
using GestaoOvos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoOvos.Services
{
    public class ProdutoService
    {
        private readonly GestaoOvosContext context;
        public ProdutoService(GestaoOvosContext context)
        {
            this.context = context;
        }

        public List<Produto> ListarProdutos()
        {
            return context.Produto.ToList();
        }
    }
}
