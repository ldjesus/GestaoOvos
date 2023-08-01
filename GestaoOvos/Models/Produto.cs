using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoOvos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double ValorBase { get; set; }      

        public Produto()
        {

        }

        public Produto(int id, string nome, double valorBase)
        {
            Id = id;
            Nome = nome;
            ValorBase = valorBase;
           
        }
    }
}
