using Domain.Models.Accounts;

namespace Domain.Services;

public interface IAccountAuthenticationService
{
    public Tokens Authenticate(Account account, string deviceId, string deviceType);
}