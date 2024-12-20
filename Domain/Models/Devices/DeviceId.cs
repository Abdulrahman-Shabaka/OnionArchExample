using Domain.Validators;

namespace Domain.Models.Devices;

public record DeviceId
{
    private const int MinLength = 15;
    private const int MaxLength = 50;

    public string Value { get; set; }

    public DeviceId(string value)
    {
        ValueValidator.AssertWithinRange(typeof(DeviceId), value, MinLength, MaxLength);
        Value = value;
    }

    public static DeviceId Create(string value) => new(value);
}