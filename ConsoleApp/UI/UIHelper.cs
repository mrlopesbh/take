using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp.UI
{
    public class UIHelper : IUIHelper
    {
        private static int _quantidadeCaracteres = 70;

        public void LimparTela()
        {
            Console.Clear();
        }

        public void ImprimirTitulo(string titulo)
        {
            Console.WriteLine(new string('*', _quantidadeCaracteres));
            Console.WriteLine(titulo);
            Console.WriteLine(new string('*', _quantidadeCaracteres));

            ImprimirLinhaBranco();
        }

        public void ImprimirLinhaBranco()
        {
            Console.WriteLine();
        }

        public void ImprimirTitulo2(string descricao)
        {
            string text = $"___ {descricao} ";
            Console.WriteLine(text + new string('_', _quantidadeCaracteres - text.Length));
        }

        public void ImprimirCabecalhoMenu()
        {
            ImprimirTitulo2("Menu");
            ImprimirLinhaBranco();
        }

        public void ImprimirMenu(string opcao, string descricao)
        {
            Console.WriteLine($"{opcao} - {descricao}");
        }

        public void ImprimirSucesso(string descritivo)
        {
            Console.WriteLine($"{descritivo}");
        }

        public void ImprimirErro(string descritivo)
        {
            Console.WriteLine($"Erro: {descritivo}");
        }

        public void ImprimirInformacao(string descritivo)
        {
            Console.WriteLine($"{descritivo}");
        }
    }
}
