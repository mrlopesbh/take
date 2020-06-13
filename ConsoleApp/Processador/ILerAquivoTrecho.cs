using ConsoleApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp.Processador
{
    public interface ILerAquivoTrecho
    {
        Task<bool> ImportarTrechos(string filePath, List<Model.Trecho> trechos);
    }
}