using ConsoleApp.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Mock.UIMocks
{
    public class UIHelperMock : IUIHelper
    {
        public List<string> lstImprimirErro = new List<string>();
        public List<string> lstImprimirSucesso = new List<string>();
        public List<string> lstImprimirInformacao = new List<string>();
        public List<string> lstImprimirTitulo = new List<string>();
        public List<string> lstImprimirTitulo2 = new List<string>();


        public int QtdImprimirCabecalho = 0;

        public int QtdImprimirLinhaBranco = 0;

        public int QtdImprimirMenu = 0;

        public int QtdLimparTela = 0;

        public void ImprimirCabecalhoMenu()
        {
            QtdImprimirCabecalho++;
        }

        public void ImprimirErro(string descritivo)
        {
            lstImprimirErro.Add(descritivo);
        }

        public void ImprimirLinhaBranco()
        {
            QtdImprimirLinhaBranco++;
        }

        public void ImprimirMenu(string opcao, string descricao)
        {
            QtdImprimirMenu++;
        }

        public void ImprimirSucesso(string descritivo)
        {
            lstImprimirSucesso.Add(descritivo);
        }

        public void ImprimirInformacao(string descritivo)
        {
            lstImprimirInformacao.Add(descritivo);
        }

        public void ImprimirTitulo(string titulo)
        {
            lstImprimirTitulo.Add(titulo);
        }

        public void ImprimirTitulo2(string descricao)
        {
            lstImprimirTitulo2.Add(descricao);
        }

        public void LimparTela()
        {
            QtdLimparTela++;
        }
    }
}
