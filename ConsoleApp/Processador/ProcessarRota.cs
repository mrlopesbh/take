using ConsoleApp.Logger;
using ConsoleApp.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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

        private void AddTrecho(string origem, string destino, decimal tempo)
        {

            var x2 = _caminhos.Where(x => x.Steps.Any(y => y.Destino == origem || y.Origem == destino)).ToList();

            var caminho = new Caminho();

            caminho.AddStep(origem, destino, tempo);

            AdicionarCaminho(caminho);

            // existem caminhos que podem começar antes, depois ou "no meio" destes caminhos já criados
            foreach (var x in x2)
            {
                MontarTodosCaminhos(x, origem, destino, tempo);
            }
        }

        private void MontarTodosCaminhos(Caminho caminhoBase, string origem, string destino, decimal tempo)
        {
            // fazer analise combinatoria mesclando os itens.

            foreach (var item in caminhoBase.Steps.OrderBy(x => x.Order))
            {
                if (item.Origem == destino)
                {
                    var t = caminhoBase.Steps.Where(x => x.Order >= item.Order).ToList(); // t = temp;
                    CriarComNovaOrigem(t, origem, tempo);
                }

                if (item.Destino == origem)
                {
                    var t = caminhoBase.Steps.Where(x => x.Order <= item.Order).ToList(); // t = temp;
                    // Ampliando a rota
                    CriarComNovaDestino(t, destino, tempo);
                }
            }
        }

        private void CriarComNovaOrigem(List<Step> list, string origem, decimal tempo)
        {
            if (list.Any(x => x.Origem == origem))
                return;

            for (int i = 0; i <= list.Count - 1; i++)
            {
                var c = new Caminho();

                c.AddStep(origem, list[i].Destino, list[i].Tempo);

                for (int y = 0; y < i; y++)
                {
                    c.AddStep(list[i].Destino, list[y].Origem, list[y].Tempo);
                }

                AdicionarCaminho(c);
            }
        }

        private void CriarComNovaDestino(List<Step> list, string destino, decimal tempo)
        {
            if (list.Any(x => x.Destino == destino))
                return;

            for (int i = 0; i <= list.Count - 1; i++)
            {
                var c = new Caminho();

                for (int y = 0; y <= list.Count - 1; y++)
                {
                    c.AddStep(list[y].Origem, list[y].Destino, list[y].Tempo);
                }

                c.AddStep(list[i].Destino, destino, tempo);

                AdicionarCaminho(c);
            }
        }

        private void AdicionarCaminho(Caminho c)
        {

            if (c.Origem != c.Destino)
                _caminhos.Add(c);
        }


        public Rotas ProcurarRota(string origem, string destino)
        {
            var melhorCaminho = _caminhos.Where(x => x.Origem == origem && x.Destino == destino).OrderBy(x => x.Tempo).FirstOrDefault();

            if (melhorCaminho == null) // não temos rota para atendimento.
                return null;

            return new Rotas(melhorCaminho.GetRota(), melhorCaminho.Tempo); ;
        }

        private class Caminho
        {
            public string Origem { get; set; }
            public string Destino { get; set; }

            public decimal Tempo { get; set; }

            public List<Step> Steps { get; set; }

            public Caminho()
            {
                Steps = new List<Step>();
            }

            public void AddStep(string origem, string destino, decimal tempo)
            {
                Steps.Add(new Step(Steps.Count, origem, destino, tempo));
                AtualizarCaminho();
            }

            public void AtualizarCaminho()
            {
                Origem = Steps.FirstOrDefault().Origem;
                Destino = Steps.LastOrDefault().Destino;

                Tempo = Steps.Sum(x => x.Tempo);
            }

            public override string ToString()
            {
                return $"{Origem} {Destino} -> {Tempo}";

            }

            public string GetRota()
            {
                StringBuilder str = new StringBuilder();

                foreach (var item in Steps)
                {
                    str.Append(item.Origem + " ");
                }

                str.Append(Steps.LastOrDefault().Destino);

                return str.ToString();
            }
        }
        public class Step
        {
            public int Order { get; set; }
            public string Origem { get; set; }
            public string Destino { get; set; }

            public decimal Tempo { get; set; }

            public Step(int order, string origem, string destino, decimal tempo)
            {
                Order = order;
                Origem = origem;
                Destino = destino;
                Tempo = tempo;
            }

            public override string ToString()
            {
                return $"{Order}| {Origem} {Destino} -> {Tempo}";
            }
        }


    }
}
