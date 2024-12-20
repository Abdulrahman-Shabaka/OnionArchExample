namespace Domain.Exceptions;

/// <summary>
/// Base class for domain exceptions.
/// </summary>
public abstract class DomainException : Exception
{
    protected DomainException(string message) : base(message)
    {
    }
}