using ConsoleApp.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Processador
{
    public class LerAquivoTrecho : ILerAquivoTrecho
    {

        Logger.ILogger _log;

        public LerAquivoTrecho(ILogger log)
        {
            _log = log;
        }

        public async Task<bool> ImportarTrechos(string filePath, List<Model.Trecho> trechos)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (reader.Peek() >= 0)
                    {
                        var line = await reader.ReadLineAsync();
                        var itens = line.Split(" ");

                        if (itens.Length != 3)
                            throw new Exception("Arquivo com formato inválido.");

                        trechos.Add(new Model.Trecho(itens[0], itens[1], decimal.Parse(itens[2])));
                    }
                }

                _log.LogInformation(@$"Foram carregados {trechos.Count} trechos.");
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
