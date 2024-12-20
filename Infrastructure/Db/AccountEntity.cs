using Domain.Models.Accounts;

namespace Infrastructure.Db;

public record AccountEntity(
    string AccountId,
    string MobileNumber,
    string? Name,
    string? ImageUrl,
    bool Blocked,
    long JoinedDate,
    long LastUpdated,
    List<string> Permissions,
    List<DeviceEntity> Devices)
{
    public static AccountEntity From(Account domain)
    {
        return new AccountEntity(
            domain.Id.Value.ToString(),
            domain.MobileNumber.Value,
            domain.FullName?.Value,
            domain.PhotoUrl?.Value,
            domain.Blocked,
            domain.JoinedDate.Ticks,
            DateTime.UtcNow.Ticks,
            domain.Permissions.Select(p => p.ToString()).ToList(),
            domain.Devices.Select(DeviceEntity.From).ToList()
        );
    }

    public Account ToDomain()
    {
        try
        {
            return new Account(
                new AccountId(Guid.Parse(AccountId)),
                new MobileNumber(MobileNumber),
                Devices.Select(d => d.ToDomain()).ToList(),
                Permissions.Select(Enum.Parse<Permission>).ToList(),
                !string.IsNullOrEmpty(Name) ? FullName.Create(Name) : null,
                !string.IsNullOrEmpty(ImageUrl) ? PhotoUrl.Create(ImageUrl) : null,
                Blocked,
                new DateTime(JoinedDate, DateTimeKind.Utc)
            );
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Could not map identity from the database - {ex.Message}", ex);
        }
    }
}