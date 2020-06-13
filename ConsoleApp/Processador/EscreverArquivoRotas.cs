using ConsoleApp.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Processador
{
    public class EscreverArquivoRotas : IEscreverArquivoRotas
    {
        ILogger _log;


        public EscreverArquivoRotas(ILogger log)
        {
            _log = log;
        }

        public async Task<bool> ExportarArquivoRota(string filePath, List<Model.Rotas> rotas)
        {
            try
            {
                using (var w = new StreamWriter(filePath))
                {
                    for (int i = 0; i <= rotas.Count; i++)
                    {
                        await w.WriteLineAsync($"{rotas[0].Rota} {rotas[0].Tempo}");
                    }
                }

                _log.LogInformation(@$"Foram exportadas {rotas.Count} rotas.");
                return true;
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                return false;
            }
        }

    }
}
