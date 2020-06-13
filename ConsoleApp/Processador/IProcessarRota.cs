using ConsoleApp.Model;
using System.Collections.Generic;

namespace ConsoleApp.Processador
{
    public interface IProcessarRota
    {
        List<Rotas> Processar(List<Trecho> trechos, List<Encomenda> encomendas);
    }
}