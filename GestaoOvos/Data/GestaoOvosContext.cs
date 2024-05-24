using Microsoft.EntityFrameworkCore;
using GestaoOvos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GestaoOvos.Data
{
    public class GestaoOvosContext : IdentityDbContext<Usuario>
    {
        public GestaoOvosContext(DbContextOptions<GestaoOvosContext> options): base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Vendas> Vendas { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<StatusPgto> StatusPgto { get; set; }
        public DbSet<StatusEntrega> StatusEntrega { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<Quantidade> Quantidade { get; set; }

    }


    //public class GestaoOvosContext : DbContext
    //{
    //    public GestaoOvosContext (DbContextOptions<GestaoOvosContext> options)
    //        : base(options)
    //    {
    //    }

    //    public DbSet<Cliente> Cliente { get; set; }
    //    public DbSet<Vendedor> Vendedor { get; set; }
    //    public DbSet<Vendas> Vendas { get; set; }
    //    public DbSet<Produto> Produto { get; set; }
    //    public DbSet<StatusPgto> StatusPgto { get; set; }
    //    public DbSet<StatusEntrega> StatusEntrega { get; set; }
    //    public DbSet<FormaPagamento> FormaPagamento { get; set; }
    //    public DbSet<Quantidade> Quantidade { get; set; }

    //}

}
