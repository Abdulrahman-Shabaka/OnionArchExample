namespace Domain.Models.Devices;

public class Device(
    DeviceId deviceId,
    DeviceType deviceType,
    DateTime lastAccessTime,
    RefreshToken? refreshToken,
    FCMToken? fcmToken)
{
    public DeviceId DeviceId { get; } = deviceId;
    public DeviceType DeviceType { get; } = deviceType;
    public RefreshToken? RefreshToken { get; private set; } = refreshToken;
    public FCMToken? FcmToken { get; private set; } = fcmToken;
    public DateTime LastAccessTime { get; private set; } = lastAccessTime;

    public static Device Of(string deviceId, string deviceType, string refreshToken) => Create(deviceId, deviceType, refreshToken);

    public static Device Of(string deviceId, string deviceType) => Create(deviceId, deviceType, null);

    public static Device Create(
        string deviceId,
        string deviceType,
        string? refreshToken,
        string? fcmToken = null,
        DateTime? lastAccessTime = null)
    {
        var deviceTypeObj = DeviceType.Create(deviceType);
        var deviceIdObj = DeviceId.Create(deviceId);
        var refreshTokenObj = refreshToken != null ? RefreshToken.Create(refreshToken) : null;
        var fcmTokenObj = fcmToken != null ? FCMToken.Create(fcmToken) : null;
        var lastAccessTimeObj = lastAccessTime ?? DateTime.Now;

        return new Device(deviceIdObj, deviceTypeObj, lastAccessTimeObj, refreshTokenObj, fcmTokenObj);
    }

    public void UpdateRefreshToken(string newRefreshToken)
    {
        RefreshToken = RefreshToken.Create(newRefreshToken);
        LastAccessTime = DateTime.Now;
    }

    public void UpdateFCMToken(string fcmToken)
    {
        FcmToken = FCMToken.Create(fcmToken);
        LastAccessTime = DateTime.Now;
    }

    public DateTime GetLastAccessTime() => LastAccessTime;
}
