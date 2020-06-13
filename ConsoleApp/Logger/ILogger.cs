namespace ConsoleApp.Logger
{
    public interface ILogger
    {
        void LogError(string description);

        void LogInformation(string description);

        void LogWarning(string description);

        void LogSucesso(string description);
    }
}