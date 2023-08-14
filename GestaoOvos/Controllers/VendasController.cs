using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoOvos.Data;
using GestaoOvos.Models;
using GestaoOvos.Services;
using GestaoOvos.Services.VendedorService;
using GestaoOvos.Models.ViewModels;

namespace GestaoOvos.Controllers
{
    public class VendasController : Controller
    {
        private readonly GestaoOvosContext _context;
        private readonly ProdutoService produtoService;
        private readonly VendaService vendaService;
        private readonly StatusPgtoService statusPgtoService;
        private readonly StatusEntregaService statusEntregaService;
        private readonly VendedorService vendedorService;
        private readonly ClienteService clienteService;
        private readonly FormaPagamentoService formaPagamentoService;
        private readonly QuantidadeService quantidadeService;
        public VendasController(GestaoOvosContext context, ProdutoService produtoService, VendaService vendaService, StatusPgtoService statusPgtoService, StatusEntregaService statusEntregaService, VendedorService vendedorService, ClienteService clienteService, FormaPagamentoService formaPagamentoService, QuantidadeService quantidadeService)
        {
            _context = context;
            this.produtoService = produtoService;
            this.vendaService = vendaService;
            this.statusPgtoService = statusPgtoService;
            this.statusEntregaService = statusEntregaService;
            this.vendedorService = vendedorService;
            this.clienteService = clienteService;
            this.formaPagamentoService = formaPagamentoService;
            this.quantidadeService = quantidadeService;
        }

        // GET: Vendas
        public IActionResult Index()
        {
            return View(vendaService.ListarVendas());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            var produtosAll = produtoService.ListarProdutos();
            var clientesAll = clienteService.ListarClientes();
            var statusPgtoAll = statusPgtoService.StatusPagamentos();
            var statusEntregaAll = statusEntregaService.StatusEntrega();
            var vendedoresAll = vendedorService.Vendedores().Result;
            var FormaPagamentoAll = formaPagamentoService.FormaPagamento();
            var quantidadeAll = quantidadeService.Quantidades();
            var viewModel = new VendasProdutosViewModel { Clientes = clientesAll, Produtos = produtosAll,Status = statusPgtoAll, Vendedores = vendedoresAll,StatusEntregas = statusEntregaAll, FormaPagamentos = FormaPagamentoAll, Quantidades = quantidadeAll };
            return View(viewModel);
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendas vendas)
        {
            vendaService.Salvar(vendas);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = vendaService.GetVendasPorId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            var produtosAll = produtoService.ListarProdutos();
            var clientesAll = clienteService.ListarClientes();
            var statusPgtoAll = statusPgtoService.StatusPagamentos();
            var statusEntregaAll = statusEntregaService.StatusEntrega();
            var vendedoresAll = vendedorService.Vendedores().Result;
            var FormaPagamentoAll = formaPagamentoService.FormaPagamento();
            var quantidadeAll = quantidadeService.Quantidades();
            var viewModel = new VendasProdutosViewModel {Vendas = obj, Clientes = clientesAll, Produtos = produtosAll, Status = statusPgtoAll, Vendedores = vendedoresAll, StatusEntregas = statusEntregaAll, FormaPagamentos = FormaPagamentoAll, Quantidades = quantidadeAll };
            return View(viewModel);

        }

        // GET: Vendas/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var vendas = await _context.Vendas.FindAsync(id);
        //    if (vendas == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(vendas);
        //}

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendas vendas)
        {
            if (id != vendas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendasExists(vendas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vendas);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendas = await _context.Vendas.FindAsync(id);
            _context.Vendas.Remove(vendas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendasExists(int id)
        {
            return _context.Vendas.Any(e => e.Id == id);
        }
    }
}
