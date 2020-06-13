using ConsoleApp.Logger;
using ConsoleApp.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Processador
{
    public class ProcessarRota : IProcessarRota
    {
        Logger.ILogger _log;

        List<Caminho> _caminhos;

        public ProcessarRota(ILogger log)
        {
            _log = log;
        }

        public List<Rotas> Processar(List<Trecho> trechos, List<Encomenda> encomendas)
        {
            var resp = new List<Rotas>();

            MontarPossiveisCaminhos(trechos);

            foreach (var encomenda in encomendas)
            {
                var rota = ProcurarRota(encomenda.Origem, encomenda.Destino);

                if (rota == null)
                {
                    _log.LogWarning($"Não foi possivel encontrar rota entre {encomenda.Origem} - {encomenda.Destino}");
                    continue;
                }

                resp.Add(rota);
            }

            return resp;
        }

        public void MontarPossiveisCaminhos(List<Trecho> trechos)
        {
            _caminhos = new List<Caminho>();

            foreach (var trecho in trechos)
            {
                AddTrecho(trecho.Origem, trecho.Destino, trecho.Duracao);
            }
        }

        private void AddTrecho(string origem, string destino, decimal tempo )
        {

            var x2 = _caminhos.Where(x => x.Steps.Any(y => y.Origem == origem || y.Destino == destino));

            var caminho = new Caminho();

            caminho.AddStep(origem, destino, tempo);

            _caminhos.Add(caminho);

            // existem caminhos que podem começar antes ou depois destes caminhos já criados
            foreach (var x in x2)
            {
                MontarTodosCaminhos(x, origem, destino, tempo);
            }
        }

        private void MontarTodosCaminhos(Caminho caminhoBase, string origem, string destino, decimal tempo)
        {
           
            
        }

        public Rotas ProcurarRota(string origem, string destino)
        {
            var melhorCaminho = _caminhos.Where(x => x.Origem == origem && x.Destino == destino).OrderBy(x => x.Tempo).FirstOrDefault();

            if (melhorCaminho == null) // não temos rota para atendimento.
                return null;

            return null;
        }

        private class Caminho
        {
            public string Origem { get; set; }
            public string Destino { get; set; }

            public decimal Tempo { get; set; }

            public LinkedList<Step> Steps { get; set; }

            public Caminho()
            {
                Steps = new LinkedList<Step>();
            }
            
            public void AddStep(string origem, string destino, decimal tempo)
            {
                Steps.AddLast(new Step(origem, destino, tempo));
                AtualizarCaminho();
            }

            public void AtualizarCaminho()
            {
                Origem = Steps.First.Value.Origem;
                Destino = Steps.Last.Value.Destino;

                Tempo = Steps.Sum(x => x.Tempo);
            }


        }
        public class Step
        {
            public string Origem { get; set; }
            public string Destino { get; set; }

            public decimal Tempo { get; set; }

            public Step(string origem, string destino, decimal tempo)
            {
                Origem = origem;
                Destino = destino;
                Tempo = tempo;
            }
        }


    }
}
