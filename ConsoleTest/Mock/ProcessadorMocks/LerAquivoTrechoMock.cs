using ConsoleApp.Model;
using ConsoleApp.Processador;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Mock.ProcessadorMocks
{
    public class LerAquivoTrechoMock : ILerAquivoTrecho
    {
        public string FilePath { get; set; }

        public List<Trecho> TrechosParaRetornar { get; set; } = new List<Trecho>();

        public bool response;

        public Task<bool> ImportarTrechos(string filePath, List<Trecho> trechos)
        {

            this.FilePath = filePath;

            trechos.AddRange(TrechosParaRetornar);

            return Task.FromResult(response);
        }
    }
}
