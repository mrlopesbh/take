using ConsoleApp.Model;
using ConsoleApp.Processador;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Mock.ProcessadorMocks
{
    public class ProcessarRotaMock : IProcessarRota
    {

        public List<Rotas> RotasParaRetornar { get; set; } = new List<Rotas>();

        public List<Trecho> TrechosPassados { get; set; } = new List<Trecho>();

        public List<Encomenda> EncomendasPassadas { get; set; } = new List<Encomenda>();

        public List<Rotas> Processar(List<Trecho> trechos, List<Encomenda> encomendas)
        {

            TrechosPassados.AddRange(trechos);
            EncomendasPassadas.AddRange(encomendas);

            return RotasParaRetornar;
        }
    }
}
