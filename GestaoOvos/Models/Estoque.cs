using System;

namespace GestaoOvos.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        
        public Produto Produto { get; set; }
        public int Quantidade { get;set; }
        public DateTime? DataEntrada{ get; set; }

    }
}
