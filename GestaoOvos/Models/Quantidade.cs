using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoOvos.Models
{
    public class Quantidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Qtd { get; set; }
        public double Valor { get; set; }
    }
}
