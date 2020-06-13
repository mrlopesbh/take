using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Model
{
    public class Trecho
    {
        public string Origem { get; set; }

        public string Destino { get; set; }

        public decimal Duracao { get; set; }

        public Trecho(string origem, string destino, decimal duracao)
        {
            Origem = origem;
            Destino = destino;
            Duracao = duracao;
        }
    }
}
