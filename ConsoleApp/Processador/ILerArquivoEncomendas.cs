using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Processador
{
    public interface ILerArquivoEncomendas
    {
        Task<bool> ImportarEncomendas(string filePath, List<Model.Encomenda> encomendas);
    }
}
