
using ConsoleApp.Logger;
using ConsoleApp.Model;
using ConsoleApp.Processador;
using ConsoleApp.UI;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class CorreiosProgram
    {
        UI.IUIHelper _uIHelper;
        Logger.ILogger _logger;
        Processador.ILerAquivoTrecho _lerAquivoTrecho;
        Processador.ILerArquivoEncomendas _lerArquivoEncomendas;
        Processador.IEscreverArquivoRotas _escreverArquivoRotas;
        Processador.IProcessarRota _processarRota;

        string _pathTrechos;
        string _pathEncomendas;
        string _pathRotas;

        bool _hasError;

        public CorreiosProgram(IUIHelper uIHelper, ILogger logger, ILerAquivoTrecho lerAquivoTrecho, ILerArquivoEncomendas lerArquivoEncomendas, 
                            IEscreverArquivoRotas escreverArquivoRotas, IProcessarRota processarRota
                            ,string pathTrechos, string pathEncomendas, string pathRotas)
        {
            _uIHelper = uIHelper;
            _logger = logger;

            _lerAquivoTrecho = lerAquivoTrecho;
            _lerArquivoEncomendas = lerArquivoEncomendas;
            _escreverArquivoRotas = escreverArquivoRotas;
            _processarRota = processarRota;

            _pathTrechos = pathTrechos;
            _pathEncomendas = pathEncomendas;
            _pathRotas = pathRotas;
        }

        public async Task Main()
        {

            _hasError = false;

            _uIHelper.ImprimirTitulo("Correios de San Andreas");

            // receber e transformar arquivo de Trechos
            var lstTrechos = new List<Trecho>();

            await CarregarTrechos(lstTrechos);

            if (_hasError)
                return;

            // receber e transformar arquivo de Encomendas
            var lstEncomendas = new List<Encomenda>();

            await CarregarEncomendas(lstEncomendas);

            if (_hasError)
                return;

            // Processar encomendas e gerar arquivo.
            var lstRotas = new List<Rotas>();

            for (int i = 0; i <= 1000; i++) lstRotas.Add(new Rotas("testetete", 2m));

            await ExportarRotas(lstRotas);

            if (_hasError)
                return;

            _uIHelper.ImprimirTitulo("Arquivos processados com sucesso.");

        }

        public async Task CarregarTrechos(List<Trecho> lstTrechos)
        {
            _logger.LogInformation("Processando arquivo de trechos");

            if (!await _lerAquivoTrecho.ImportarTrechos(_pathTrechos, lstTrechos))
            {
                TratarInterrupcao("Não foi possivel carregar o arquivo de trechos identificado");
            }

            _uIHelper.ImprimirLinhaBranco();
        }

        public async Task CarregarEncomendas(List<Encomenda> lstEncomendas)
        {
            _logger.LogInformation("Processando arquivo de Encomendas");

            if (!await _lerArquivoEncomendas.ImportarEncomendas(_pathEncomendas, lstEncomendas))
            {
                TratarInterrupcao("Não foi possivel carregar o arquivo de encomendas identificado");
            }

            _uIHelper.ImprimirLinhaBranco();
        }

        public async Task ExportarRotas(List<Rotas> lstRotas)
        {
            _logger.LogInformation("Exportando arquivo com rotas");

            if (!await _escreverArquivoRotas.ExportarArquivoRota(_pathRotas, lstRotas))
            {
                TratarInterrupcao("Não foi possivel escrever o arquivo de encomendas identificado");
            }

            _uIHelper.ImprimirLinhaBranco();

        }

        public void TratarInterrupcao(string descricao)
        {
            _logger.LogError(descricao);
            _hasError = true;
        }


    }
}
