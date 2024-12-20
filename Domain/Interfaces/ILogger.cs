namespace Domain.Interfaces;

public interface ILogger
{
    void Log(string message);
    void WarningLog(string message);
    void ErrorLog(string message);
}