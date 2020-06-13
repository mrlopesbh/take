using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Logger
{
    public class Logger : ILogger
    {

        UI.IUIHelper _uiHelper;

        public Logger(UI.IUIHelper uiHelper)
        {
            _uiHelper = uiHelper;
        }

        public void LogInformation(string description)
        {
            _uiHelper.ImprimirInformacao(description);
        }

        public void LogError(string description)
        {
            _uiHelper.ImprimirErro(description);
        }

        public void LogSucesso(string description)
        {
            _uiHelper.ImprimirSucesso(description);
        }

        public void LogWarning(string description)
        {
            _uiHelper.ImprimirErro(description);
        }
    }
}
