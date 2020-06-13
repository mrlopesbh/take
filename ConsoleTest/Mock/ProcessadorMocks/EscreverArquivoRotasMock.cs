using ConsoleApp.Model;
using ConsoleApp.Processador;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Mock.ProcessadorMocks
{
    public class EscreverArquivoRotasMock : IEscreverArquivoRotas
    {

        public string FilePath { get; set; }

        public List<Rotas> RotasEnviadas { get; set; } = new List<Rotas>();

        public bool response;

        public Task<bool> ExportarArquivoRota(string filePath, List<Rotas> rotas)
        {
            this.FilePath = filePath;

            RotasEnviadas.AddRange(rotas);

            return Task.FromResult(response);
        }
    }
}
