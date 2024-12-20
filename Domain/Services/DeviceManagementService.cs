using Domain.Models.Accounts;
using Domain.Models.Devices;

namespace Domain.Services;

public class DeviceManagementService : IDeviceManagementService
{
    public Device GetOrCreateUsedDevice(Account account, string deviceId, string deviceType)
    {
        var usedDevice = GetDevice(account, deviceId) ?? Device.Of(deviceId, deviceType);
        return usedDevice;
    }

    public Device? GetDevice(Account account, string deviceId) => account.Devices.FirstOrDefault(device => device?.DeviceId.Value == deviceId);
}