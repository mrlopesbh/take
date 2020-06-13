using ConsoleApp.UI;
using ConsoleApp.Processador;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTest.Mock.UIMocks;
using ConsoleApp.Logger;
using ConsoleTest.Mock.ProcessadorMocks;
using ConsoleApp;
using ConsoleApp.Model;
using Xunit;
using ConsoleTest.Mock.LoggerMock;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class CorreiosProgramTests
    {

        UIHelperMock _uIHelper;
        LoggerMock _logger;
        LerAquivoTrechoMock _lerAquivoTrecho;
        LerArquivoEncomendasMock _lerArquivoEncomendas;
        EscreverArquivoRotasMock _escreverArquivoRotas;
        ProcessarRotaMock _processarRota;


        List<Trecho> lstTrechos;
        List<Encomenda> lstEncomendas;
        List<Rotas> lstRotas;

        [Fact]
        public void TestAoOcrrerInterrupacaoDeveRepassarADescricaoParaLog()
        {
            var b = Build("", "", "");

            b.TratarInterrupcao("Erro X");

            Assert.Equal("Erro X", _logger.LstLogError.LastOrDefault());
        }

        #region Testes sobre carregament de Trechos

        private  CorreiosProgram CarregarTrecho_ExecucaPerfeita()
        {
            var b = Build("A", "B", "C");

            _lerAquivoTrecho.response = true;
            _lerAquivoTrecho.TrechosParaRetornar.Add(new Trecho("AB", "BA", 1));
            _lerAquivoTrecho.TrechosParaRetornar.Add(new Trecho("CB", "BC", 2));

            return b;

        }

        [Fact]
        public async Task TestCarregarTrecho_AoExcutarDaFormaCorreta_DeveTer1LogInfRegistrare1LinhaVazia()
        {
            var b = CarregarTrecho_ExecucaPerfeita();

            await b.CarregarTrechos(lstTrechos);

            Assert.Single(_logger.lstLogInformacao);
            Assert.Equal(1, _uIHelper.QtdImprimirLinhaBranco);

        }

        [Fact]
        public async Task TestCarregarTrecho_AoExcutarDaFormaCorreta_DeveRetornarTrechosPassados()
        {
            var b = CarregarTrecho_ExecucaPerfeita();

            await b.CarregarTrechos(lstTrechos);

            Assert.Equal(_lerAquivoTrecho.TrechosParaRetornar, lstTrechos);
        }


        [Fact]
        public async Task TestCarregarTrecho_AoExcutarDeFormaErrada_DeveRegistrarLog()
        {
            var b = Build("A", "B", "C");

            _lerAquivoTrecho.response = false;

            await b.CarregarTrechos(lstTrechos);

            Assert.Equal("Não foi possivel carregar o arquivo de trechos identificado", _logger.LstLogError.LastOrDefault());
        }

        #endregion


        private void ResetReferences()
        {
            _uIHelper = new UIHelperMock();

            _logger = new LoggerMock();

            _escreverArquivoRotas = new EscreverArquivoRotasMock();
            _lerAquivoTrecho = new LerAquivoTrechoMock();
            _lerArquivoEncomendas = new LerArquivoEncomendasMock();
            _processarRota = new ProcessarRotaMock();


            lstTrechos = new List<Trecho>();
            lstEncomendas = new List<Encomenda>();
            lstRotas = new List<Rotas>();
        }

        private CorreiosProgram Build(string filePathArquivoTrecho, string filePathArquivoEncmendas, string filePathRotas)
        {
            ResetReferences();

            CorreiosProgram b = new CorreiosProgram(_uIHelper, _logger, _lerAquivoTrecho, _lerArquivoEncomendas, _escreverArquivoRotas, _processarRota, filePathArquivoTrecho, filePathArquivoEncmendas, filePathRotas);

            return b;
        }



    }
}
