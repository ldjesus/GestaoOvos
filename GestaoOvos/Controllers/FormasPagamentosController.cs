﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoOvos.Data;
using GestaoOvos.Models;

namespace GestaoOvos.Controllers
{
    public class FormasPagamentosController : Controller
    {
        private readonly GestaoOvosContext _context;

        public FormasPagamentosController(GestaoOvosContext context)
        {
            _context = context;
        }

        // GET: FormasPagamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormaPagamento.ToListAsync());
        }

        // GET: FormasPagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagamento = await _context.FormaPagamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formaPagamento == null)
            {
                return NotFound();
            }

            return View(formaPagamento);
        }

        // GET: FormasPagamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormasPagamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] FormaPagamento formaPagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formaPagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formaPagamento);
        }

        // GET: FormasPagamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagamento = await _context.FormaPagamento.FindAsync(id);
            if (formaPagamento == null)
            {
                return NotFound();
            }
            return View(formaPagamento);
        }

        // POST: FormasPagamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] FormaPagamento formaPagamento)
        {
            if (id != formaPagamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formaPagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormaPagamentoExists(formaPagamento.Id))
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
            return View(formaPagamento);
        }

        // GET: FormasPagamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagamento = await _context.FormaPagamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formaPagamento == null)
            {
                return NotFound();
            }

            return View(formaPagamento);
        }

        // POST: FormasPagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formaPagamento = await _context.FormaPagamento.FindAsync(id);
            _context.FormaPagamento.Remove(formaPagamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormaPagamentoExists(int id)
        {
            return _context.FormaPagamento.Any(e => e.Id == id);
        }
    }
}
