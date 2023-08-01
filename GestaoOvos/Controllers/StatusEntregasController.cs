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
    public class StatusEntregasController : Controller
    {
        private readonly GestaoOvosContext _context;

        public StatusEntregasController(GestaoOvosContext context)
        {
            _context = context;
        }

        // GET: StatusEntregas
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusEntrega.ToListAsync());
        }

        // GET: StatusEntregas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusEntrega = await _context.StatusEntrega
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusEntrega == null)
            {
                return NotFound();
            }

            return View(statusEntrega);
        }

        // GET: StatusEntregas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusEntregas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] StatusEntrega statusEntrega)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusEntrega);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusEntrega);
        }

        // GET: StatusEntregas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusEntrega = await _context.StatusEntrega.FindAsync(id);
            if (statusEntrega == null)
            {
                return NotFound();
            }
            return View(statusEntrega);
        }

        // POST: StatusEntregas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] StatusEntrega statusEntrega)
        {
            if (id != statusEntrega.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusEntrega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusEntregaExists(statusEntrega.Id))
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
            return View(statusEntrega);
        }

        // GET: StatusEntregas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusEntrega = await _context.StatusEntrega
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusEntrega == null)
            {
                return NotFound();
            }

            return View(statusEntrega);
        }

        // POST: StatusEntregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusEntrega = await _context.StatusEntrega.FindAsync(id);
            _context.StatusEntrega.Remove(statusEntrega);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusEntregaExists(int id)
        {
            return _context.StatusEntrega.Any(e => e.Id == id);
        }
    }
}
