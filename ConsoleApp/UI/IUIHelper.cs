namespace ConsoleApp.UI
{
    public interface IUIHelper
    {
        void ImprimirCabecalhoMenu();
        void ImprimirErro(string descritivo);
        void ImprimirLinhaBranco();
        void ImprimirMenu(string opcao, string descricao);
        void ImprimirSucesso(string descritivo);

        void ImprimirInformacao(string descritivo);
        void ImprimirTitulo(string titulo);
        void ImprimirTitulo2(string descricao);
        void LimparTela();
    }
}