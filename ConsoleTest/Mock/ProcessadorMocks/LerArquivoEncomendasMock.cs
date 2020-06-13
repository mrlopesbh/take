using ConsoleApp.Model;
using ConsoleApp.Processador;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Mock.ProcessadorMocks
{
    public class LerArquivoEncomendasMock : ILerArquivoEncomendas
    {

        public string FilePath { get; set; }

        public List<Encomenda> EncomendasParaRetornar { get; set; } = new List<Encomenda>();

        public bool response;

        public Task<bool> ImportarEncomendas(string filePath, List<Encomenda> encomendas)
        {

            this.FilePath = filePath;

            encomendas.AddRange(EncomendasParaRetornar);

            return Task.FromResult(response);

        }
    }
}
