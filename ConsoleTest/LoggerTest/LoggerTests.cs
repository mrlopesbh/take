using ConsoleApp.Logger;
using ConsoleTest.Mock;
using ConsoleTest.Mock.UIMocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ConsoleTest.LoggerTest
{
    public class LoggerTests
    {

        private UIHelperMock uIHelperMock;

        private void Limpar()
        {
            uIHelperMock = new UIHelperMock();
        }

        private ILogger Build()
        {
            Limpar();
            return new ConsoleApp.Logger.Logger(uIHelperMock);
        }

        [Fact]
        public void SempreQueLogarInformacaoDeveImprimirNaTelaComoInformacao()
        {
            var l = Build();

            l.LogInformation("teste");

            Assert.Equal("teste", uIHelperMock.lstImprimirInformacao.FirstOrDefault());
        }

        [Fact]
        public void SempreQueLogarSucessoDeveImprimirNaTelaComoSucesso()
        {
            var l = Build();

            l.LogSucesso("teste");

            Assert.Equal("teste", uIHelperMock.lstImprimirSucesso.FirstOrDefault());
        }

        [Fact]
        public void SempreQueLogarErroDeveImprimirNaTelaComoErro()
        {
            var l = Build();

            l.LogError("teste");

            Assert.Equal("teste", uIHelperMock.lstImprimirErro.FirstOrDefault());
        }

    }
}
