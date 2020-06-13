using ConsoleApp.Logger;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Mock.LoggerMock
{
    public class LoggerMock : ILogger
    {
        public List<string> LstLogError = new List<string>();
        public List<string> lstLogSucesso = new List<string>();
        public List<string> lstLogInformacao = new List<string>();
        public List<string> lstLogWarning = new List<string>();

        public void LogInformation(string description)
        {
            lstLogInformacao.Add(description);
        }

        public void LogError(string description)
        {
            LstLogError.Add(description);
        }

        public void LogSucesso(string description)
        {
            lstLogSucesso.Add(description);
        }

        public void LogWarning(string description)
        {
            lstLogWarning.Add(description);
        }
    }
}
