namespace Domain.Exceptions;

/// <summary>
/// Custom Exception class hierarchy extending System.Exception.
/// </summary>
public abstract class AppException : Exception
{
    protected AppException(string message) : base(message)
    {
    }

    protected AppException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Exception for requirement violations.
    /// </summary>
    public class RequirementException : AppException
    {
        public RequirementException(string description) : base(description)
        {
        }
    }

    /// <summary>
    /// Exception for bad request errors.
    /// </summary>
    public class BadRequestException : AppException
    {
        public BadRequestException(string? description)
            : base("Bad Request: " + (description ?? string.Empty))
        {
        }
    }

    /// <summary>
    /// Exception for unauthorized access.
    /// </summary>
    public class UnauthorizedAccessException : AppException
    {
        public UnauthorizedAccessException(string? description)
            : base("Unauthorized: " + (description ?? string.Empty))
        {
        }

        public UnauthorizedAccessException() : base("Unauthorized")
        {
        }
    }

    /// <summary>
    /// Exception for not found errors.
    /// </summary>
    public class NotFoundException : AppException
    {
        public NotFoundException(string? description)
            : base("Not Found: " + (description ?? string.Empty))
        {
        }
    }
}