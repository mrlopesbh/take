using ConsoleApp.Model;
using ConsoleApp.Processador;
using ConsoleTest.Mock.LoggerMock;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConsoleTest.ProcessadorTests
{
    public class ProcessarRotaTests
    {

        [Fact]
        public void Teste1()
        {


            var log = new LoggerMock();

            var pr = new ProcessarRota(log);

            var trechos = new List<Trecho>();

            trechos.Add(new Trecho("AB", "BC", 1m));
            trechos.Add(new Trecho("BC", "DD", 1m));
            trechos.Add(new Trecho("CD", "BC", 1m));
            trechos.Add(new Trecho("EF", "BC", 1m));
            trechos.Add(new Trecho("AB", "EF", 1m));
            trechos.Add(new Trecho("CD", "EF", 1m));
            trechos.Add(new Trecho("BC", "CD", 1m));

            pr.MontarPossiveisCaminhos(trechos);

        }




    }
}
