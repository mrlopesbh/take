using ConsoleApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp.Processador
{
    public interface IEscreverArquivoRotas
    {
        Task<bool> ExportarArquivoRota(string filePath, List<Rotas> rotas);
    }
}