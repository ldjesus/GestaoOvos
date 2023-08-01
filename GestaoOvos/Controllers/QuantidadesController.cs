using System;
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
    public class QuantidadesController : Controller
    {
        private readonly GestaoOvosContext _context;

        public QuantidadesController(GestaoOvosContext context)
        {
            _context = context;
        }

        // GET: Quantidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quantidade.ToListAsync());
        }

        // GET: Quantidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quantidade = await _context.Quantidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quantidade == null)
            {
                return NotFound();
            }

            return View(quantidade);
        }

        // GET: Quantidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quantidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Qtd,Valor")] Quantidade quantidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quantidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quantidade);
        }

        // GET: Quantidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quantidade = await _context.Quantidade.FindAsync(id);
            if (quantidade == null)
            {
                return NotFound();
            }
            return View(quantidade);
        }

        // POST: Quantidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Qtd,Valor")] Quantidade quantidade)
        {
            if (id != quantidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quantidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuantidadeExists(quantidade.Id))
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
            return View(quantidade);
        }

        // GET: Quantidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quantidade = await _context.Quantidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quantidade == null)
            {
                return NotFound();
            }

            return View(quantidade);
        }

        // POST: Quantidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quantidade = await _context.Quantidade.FindAsync(id);
            _context.Quantidade.Remove(quantidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuantidadeExists(int id)
        {
            return _context.Quantidade.Any(e => e.Id == id);
        }
    }
}
