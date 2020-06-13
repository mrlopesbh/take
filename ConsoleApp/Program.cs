using ConsoleApp.Processador;
using System;
using System.Runtime.InteropServices;

namespace ConsoleApp
{
    class Program
    {


        static void Main(string[] args)
        {
            
            var b = Builder();

            b.Main().Wait();

            Console.Read();
        }


        private static CorreiosProgram Builder()
        {
            UI.IUIHelper uIHelper;
            Logger.ILogger logger;
            Processador.ILerAquivoTrecho lerAquivoTrecho;
            Processador.ILerArquivoEncomendas lerArquivoEncomendas;
            Processador.IEscreverArquivoRotas escreverArquivoRotas;
            Processador.IProcessarRota processarRota;

            // Geralmente utilizaria uma ferramenta de DI
            // mas como não ficou claro para mim se poderia utilizar ou não

            uIHelper = new UI.UIHelper();
            logger = new Logger.Logger(uIHelper);

            lerAquivoTrecho = new Processador.LerAquivoTrecho(logger);
            lerArquivoEncomendas = new Processador.LerArquivoEncomendas(logger);
            escreverArquivoRotas = new EscreverArquivoRotas(logger);
            processarRota = new Processador.ProcessarRota(logger);

            return new CorreiosProgram(uIHelper, logger, lerAquivoTrecho, lerArquivoEncomendas, escreverArquivoRotas, processarRota,
                @"C:\Users\marce\source\repos\TesteCoreNet\Arquivos\trechos.txt",
                @"C:\Users\marce\source\repos\TesteCoreNet\Arquivos\encomendas.txt",
                @"C:\Users\marce\source\repos\TesteCoreNet\Arquivos\rotas.txt");

        }


    }
}
