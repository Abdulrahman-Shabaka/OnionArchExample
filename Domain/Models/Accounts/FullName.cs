using Domain.Validators;

namespace Domain.Models.Accounts;

public record FullName
{
    private const int MinLength = 2;
    private const int MaxLength = 50;

    private FullName(string value)
    {
        ValueValidator.AssertWithinRange(typeof(FullName), value, MinLength, MaxLength);

        Value = value;
    }

    public string Value { get; set; }

    public static FullName Create(string value) => new(value);
}