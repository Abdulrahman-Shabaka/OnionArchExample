using Domain.Validators;

namespace Domain.Models.Devices;

public class FCMToken : IEquatable<FCMToken>
{
    public string Value { get; }

    private FCMToken(string value)
    {
        ValueValidator.AssertNotEmpty(value, typeof(FCMToken));
        Value = value;
    }

    public static FCMToken Create(string value) => new(value);

    public override bool Equals(object? obj)
    {
        if (obj is FCMToken token)
        {
            return Equals(token);
        }
        return false;
    }

    public bool Equals(FCMToken? other) => other != null && Value == other.Value;

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => $"FCMToken{{value='{Value}'}}";
}