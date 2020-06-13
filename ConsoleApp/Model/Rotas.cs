using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Model
{
    public class Rotas
    {
        public Rotas(string rota, decimal tempo)
        {
            Rota = rota;
            Tempo = tempo;
        }

        public string Rota { get; set; }

        public decimal Tempo { get; set; }
    }
}
