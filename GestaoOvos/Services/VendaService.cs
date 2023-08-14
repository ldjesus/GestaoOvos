using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GestaoOvos.Data;
using GestaoOvos.Models;
using GestaoOvos.Services.Exception;
using Microsoft.EntityFrameworkCore;

namespace GestaoOvos.Services
{
    public class VendaService
    {
        private readonly GestaoOvosContext context;
        public VendaService(GestaoOvosContext context)
        {
            this.context = context;
        }

        public List<Vendas> ListarVendas()
        {
            return context.Set<Vendas>()
                .Include(obj => obj.Cliente)
                .Include(obj => obj.FormaPagamento)
                .Include(obj => obj.StatusEntrega)
                .Include(obj => obj.StatusPgto)
                .Include(obj => obj.Vendedor)
                .Include(obj => obj.Produto)
                .Include(obj => obj.Quantidade)
                .ToList();

        }

        public Vendas GetVendasPorId(int id)
        {
            return context.Vendas.Include(obj => obj.Cliente).FirstOrDefault(obj => obj.Id == id);
        }

        public void Update(Vendas obj)
        {
            if (!context.Vendas.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("ID da venda não encontrada");
            }
            try
            {
                context.Update(obj);
                context.SaveChanges();
            }
            catch (DbConcurrencyException msg)
            {
                throw new DbConcurrencyException(msg.Message);
            }

        }

        public string Salvar(Vendas venda)
        {
            try
            {
                venda.DataVenda = DateTime.Now;
                context.Vendas.Add(venda);
                context.SaveChanges();
                return "Venda realizado com sucesso.";
            }
            catch (System.Exception ex)
            {
                return "Erro ao salvar a venda" + ex.Message;
            }

        }
    }
}

