using ConsoleApp.Processador;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace ConsoleApp
{
    class Program
    {


        static void Main(string[] args)
        {

            if (args.Count() != 3)
            {
                Console.WriteLine("Parametros inválidos");
                Console.Read();
                return;
            }


            var b = Builder(args[0], args[1], args[2]);

            b.Main().Wait();

            Console.Read();
        }


        private static CorreiosProgram Builder(string pathTrechos, string pathEncomendas, string pathRotas)
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

            return new CorreiosProgram(uIHelper, logger, lerAquivoTrecho, lerArquivoEncomendas, escreverArquivoRotas, processarRota, pathTrechos,  pathEncomendas,  pathRotas);

        }


    }
}
