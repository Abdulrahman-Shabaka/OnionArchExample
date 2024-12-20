using System.Text.RegularExpressions;
using Domain.Exceptions;

namespace Domain.Validators;

public static class ValueValidator
{
    /// <summary>
    ///     Validates that the string is not null or empty.
    /// </summary>
    public static void AssertNotEmpty(string value, Type type)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new AppException.BadRequestException($"{type.Name} cannot be empty");
    }

    /// <summary>
    ///     Validates that the string is within the specified length range.
    /// </summary>
    public static void AssertWithinRange(Type type, string value, int minLength, int maxLength)
    {
        if (value.Length < minLength || value.Length > maxLength)
            throw new AppException.BadRequestException(
                $"{type.Name} must be between {minLength} and {maxLength} characters");
    }

    /// <summary>
    ///     Validates that the string matches the specified regular expression.
    /// </summary>
    public static void AssertValidFormat(string value, Regex pattern, Type type)
    {
        if (!pattern.IsMatch(value)) throw new AppException.BadRequestException($"{type.Name} has an invalid format");
    }
}