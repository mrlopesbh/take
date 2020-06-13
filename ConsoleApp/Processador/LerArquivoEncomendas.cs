using ConsoleApp.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Processador
{
    class LerArquivoEncomendas : ILerArquivoEncomendas
    {

        Logger.ILogger _log;

        public LerArquivoEncomendas(ILogger log)
        {
            _log = log;
        }

        
        public async Task<bool> ImportarEncomendas(string filePath, List<Model.Encomenda> encomendas)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (reader.Peek() >= 0)
                    {
                        var line = await reader.ReadLineAsync();
                        var itens = line.Split(" ");

                        if (itens.Length != 2)
                            throw new Exception("Arquivo com formato inválido.");

                        encomendas.Add(new Model.Encomenda(itens[0], itens[1]));
                    }
                }

                _log.LogInformation(@$"Foram carregados {encomendas.Count} encomendas.");
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
