using System.Text.RegularExpressions;
using Domain.Validators;

namespace Domain.Models.Accounts;

public record PhotoUrl
{
    private static readonly Regex UrlPattern = new(
        @"https?://(www\.)?[-a-zA-Z0-9@:%._+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_+.~#?&//=]*)");

    public string? Value { get; }

    private PhotoUrl(string? value)
    {
        ValueValidator.AssertNotEmpty(value, typeof(PhotoUrl));

        ValueValidator.AssertValidFormat(value, UrlPattern, typeof(PhotoUrl));

        Value = value;
    }

    public static PhotoUrl Create(string value) => new(value);

    public string? GetValue() => Value;
}