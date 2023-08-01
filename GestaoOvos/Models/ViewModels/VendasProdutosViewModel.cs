using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoOvos.Models.ViewModels
{
    public class VendasProdutosViewModel
    {
        public Vendas Vendas { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public ICollection<StatusPgto> Status { get; set; }
        public ICollection<StatusEntrega> StatusEntregas { get; set; }
        public ICollection<FormaPagamento> FormaPagamentos { get; set; }
        public ICollection<Quantidade> Quantidades { get; set; }

    }
}
