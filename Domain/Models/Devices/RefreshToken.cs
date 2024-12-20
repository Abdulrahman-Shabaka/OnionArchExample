using Domain.Validators;

namespace Domain.Models.Devices;

public class RefreshToken
{
    public string Value { get; }

    private RefreshToken(string value)
    {
        ValueValidator.AssertNotEmpty(value, typeof(RefreshToken));
        Value = value;
    }

    public static RefreshToken Create(string value) => new(value);

    public override bool Equals(object? obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        var that = (RefreshToken)obj;
        return string.Equals(Value, that.Value);
    }

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => $"RefreshToken{{value='{Value}'}}";
}