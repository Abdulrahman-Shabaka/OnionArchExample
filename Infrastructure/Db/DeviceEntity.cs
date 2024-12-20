using Domain.Models.Devices;

namespace Infrastructure.Db;

public record DeviceEntity(
    string DeviceId,
    string DeviceType,
    string RefreshToken,
    string FcmToken,
    long LastAccessTime)
{
    public static DeviceEntity From(Device domain)
    {
        return new DeviceEntity(
            domain.DeviceId.Value,
            domain.DeviceType.Value,
            domain.RefreshToken?.Value ?? string.Empty,
            domain.FcmToken?.Value ?? string.Empty,
            domain.LastAccessTime.Ticks
        );
    }

    public Device ToDomain()
    {
        return Device.Create(
            DeviceId,
            DeviceType,
            RefreshToken,
            FcmToken,
            new DateTime(LastAccessTime, DateTimeKind.Utc)
        );
    }
}