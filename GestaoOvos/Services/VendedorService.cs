using GestaoOvos.Data;
using GestaoOvos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GestaoOvos.Services.VendedorService
{
    public class VendedorService
    {
        private readonly GestaoOvosContext _context;

        public VendedorService(GestaoOvosContext context)
        {
            _context = context;
        }

       
        public async Task<List<Vendedor>> Vendedores()
        {
            return await _context.Vendedor.ToListAsync();
        }

        
        public async Task<Vendedor> Detalhes(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var vendedor = await _context.Vendedor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendedor == null)
            {
                return null;
            }

            return vendedor;
        }

       
        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
