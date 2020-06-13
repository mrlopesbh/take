using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Model
{
    public class Encomenda
    {
        public string Origem { get; set; }
        public string Destino { get; set; }


        public Encomenda(string origem, string destino)
        {
            Origem = origem;
            Destino = destino;
        }


    }
}
