using Domain.Interfaces;
using Domain.Models.Accounts;

namespace Infrastructure.Repositories;

public class AccountRepo : IAccountRepo
{
    public Task<Account?> GetByMobileNumberAsync(string mobileNumber)
    {
        return Task.FromResult(Account.NewAccount(mobileNumber, true, "ios", "12"))!;
    }

    public Task SaveAsync(Account account)
    {
        return Task.CompletedTask;
    }

    public Task<bool> IsAdminAsync(string mobileNumber)
    {
        return Task.FromResult(true);
    }
}