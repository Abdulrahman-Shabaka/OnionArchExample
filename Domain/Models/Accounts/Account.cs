using Domain.Interfaces;
using Domain.Models.Devices;
using Domain.Services;

namespace Domain.Models.Accounts;

public class Account(
    AccountId id,
    MobileNumber mobileNumber,
    List<Device> devices,
    List<Permission>? permissions,
    FullName? fullName,
    PhotoUrl? photoUrl,
    bool blocked,
    DateTime joinedDate)
{
    public MobileNumber MobileNumber { get; } = mobileNumber;
    public IReadOnlyList<Permission> Permissions { get; } = permissions ?? [Permission.View];
    public AccountId Id { get; } = id;
    public FullName? FullName { get; set; } = fullName;
    public PhotoUrl? PhotoUrl { get; set; } = photoUrl;
    public DateTime JoinedDate { get; } = joinedDate != default ? joinedDate : DateTime.Now;
    public List<Device?> Devices { get; } = [..devices];
    public bool Blocked { get; set; } = blocked;

    public static Account NewAccount(string mobileNumber, bool isAdmin, string deviceType, string deviceId)
    {
        var device = Device.Of(deviceId, deviceType);

        return new Account(
            AccountId.New(),
            MobileNumber.Of(mobileNumber),
            [device],
            [PermissionExtensions.Of(isAdmin)],
            null,
            null,
            false,
            DateTime.Now
        );
    }

    public Tokens Authenticate(IAccountAuthenticationService authenticationService, IJWTGenerator jwtGenerator, string deviceId, string deviceType) => authenticationService.Authenticate(this, deviceId, deviceType);

    public Device? GetOrCreateUsedDevice(IDeviceManagementService deviceManagementService,string deviceId, string deviceType) => deviceManagementService.GetOrCreateUsedDevice(this, deviceId, deviceType);

    //Getters
    public IReadOnlyList<Permission>? GetPermissions() => permissions?.AsReadOnly();

    public DateTime GetJoinedDate() => new(joinedDate.Ticks);

    public IReadOnlyList<Device> GetDevices() => devices.AsReadOnly();
}