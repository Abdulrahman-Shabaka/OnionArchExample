using Domain.Interfaces;
using Domain.Models.Accounts;

namespace Domain.Services;

public class AccountAuthenticationService(IDeviceManagementService deviceManagementService, IJWTGenerator jwtGenerator) : IAccountAuthenticationService
{
    public Tokens Authenticate(Account account, string deviceId, string deviceType)
    {
        var usedDevice = account.GetOrCreateUsedDevice(deviceManagementService, deviceId, deviceType);

        var refreshToken = jwtGenerator.GenerateRefreshToken(account, usedDevice);
        usedDevice?.UpdateRefreshToken(refreshToken);

        var accessToken = jwtGenerator.GenerateAccessToken(account, usedDevice);
        return new Tokens(refreshToken, accessToken);
    }
}