using Domain.Interfaces;

namespace Infrastructure.Services.Firebase;

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Log : {message}");
    }

    public void WarningLog(string message)
    {
        Console.WriteLine($"WarningLog : {message}");
    }

    public void ErrorLog(string message)
    {
        Console.WriteLine($"ErrorLog : {message}");
    }
}