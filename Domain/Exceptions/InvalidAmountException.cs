namespace Domain.Exceptions;

/// <summary>
///     Exception thrown for invalid amounts.
/// </summary>
public class InvalidAmountException : DomainException
{
    public InvalidAmountException() : base(string.Empty)
    {
    }

    public InvalidAmountException(string message) : base(message)
    {
    }
}