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
    public class StatusPgtosController : Controller
    {
        private readonly GestaoOvosContext _context;

        public StatusPgtosController(GestaoOvosContext context)
        {
            _context = context;
        }

        // GET: StatusPgtos
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusPgto.ToListAsync());
        }

        // GET: StatusPgtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusPgto = await _context.StatusPgto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusPgto == null)
            {
                return NotFound();
            }

            return View(statusPgto);
        }

        // GET: StatusPgtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusPgtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] StatusPgto statusPgto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusPgto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusPgto);
        }

        // GET: StatusPgtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusPgto = await _context.StatusPgto.FindAsync(id);
            if (statusPgto == null)
            {
                return NotFound();
            }
            return View(statusPgto);
        }

        // POST: StatusPgtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] StatusPgto statusPgto)
        {
            if (id != statusPgto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusPgto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusPgtoExists(statusPgto.Id))
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
            return View(statusPgto);
        }

        // GET: StatusPgtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusPgto = await _context.StatusPgto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusPgto == null)
            {
                return NotFound();
            }

            return View(statusPgto);
        }

        // POST: StatusPgtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusPgto = await _context.StatusPgto.FindAsync(id);
            _context.StatusPgto.Remove(statusPgto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusPgtoExists(int id)
        {
            return _context.StatusPgto.Any(e => e.Id == id);
        }
    }
}
