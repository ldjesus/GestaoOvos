using GestaoOvos.Models;
using System;

namespace GestaoOvos.Data.Dto
{
    public class CreateVendaDto
    {
        public DateTime DataVenda { get; set; }
        public DateTime? DataPagamento { get; set; }
        public Quantidade Quantidade { get; set; }
        public int Qtd { get; set; }
        public double Total { get; set; }
        public Vendedor Vendedor { get; set; }
        public int VendedorId { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public StatusPgto StatusPgto { get; set; }
        public int StatusPgtoId { get; set; }
        public StatusEntrega StatusEntrega { get; set; }
        public int StatusEntregaId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public int FormaPagamentoId { get; set; }
        public int ValorTotal { get; set; }
    }
}
