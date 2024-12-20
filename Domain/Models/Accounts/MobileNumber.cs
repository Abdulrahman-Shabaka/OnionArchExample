using System.Text.RegularExpressions;
using Domain.Validators;

namespace Domain.Models.Accounts;

public record MobileNumber
{
    private const int MinLength = 7;
    private const int MaxLength = 15;
    private static readonly Regex MobilePattern = new("^[0-9]*$");

    public string Value{ get; set; }

    public MobileNumber(string value)
    {
        ValueValidator.AssertWithinRange(typeof(MobileNumber), value, MinLength, MaxLength);
        ValueValidator.AssertValidFormat(value, MobilePattern, typeof(MobileNumber));

        Value = value;
    }

    public static MobileNumber Of(string value)
    {
        var modifiedNumber = value;
        if (modifiedNumber.StartsWith("00")) modifiedNumber = modifiedNumber[2..];
        if (modifiedNumber.StartsWith("+")) modifiedNumber = modifiedNumber[1..];

        return new MobileNumber(modifiedNumber);
    }
}