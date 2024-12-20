using Domain.Models.Accounts;
using Domain.Models.Devices;

namespace Domain.Services;

public interface IDeviceManagementService
{
    public Device GetOrCreateUsedDevice(Account account, string deviceId, string deviceType);
}