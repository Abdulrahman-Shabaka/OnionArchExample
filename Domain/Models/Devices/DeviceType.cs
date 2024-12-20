namespace Domain.Models.Devices;

public record DeviceType(string Value)
{
    public static DeviceType Create(string value)
    {
        var normalizedValue = value.ToLowerInvariant();

        return normalizedValue switch
        {
            "android" or "ios" or "web" => new DeviceType(value),
            _ => throw new ArgumentException("Invalid device type", nameof(value))
        };
    }
}