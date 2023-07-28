using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestaoOvos.Models;

namespace GestaoOvos.Data
{
    public class GestaoOvosContext : DbContext
    {
        public GestaoOvosContext (DbContextOptions<GestaoOvosContext> options)
            : base(options)
        {
        }

        public DbSet<GestaoOvos.Models.Cliente> Cliente { get; set; }
    }
}
