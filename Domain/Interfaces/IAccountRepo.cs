using Domain.Models.Accounts;

namespace Domain.Interfaces;

public interface IAccountRepo
{
    Task<Account?> GetByMobileNumberAsync(string mobileNumber);
    Task SaveAsync(Account account);
    Task<bool> IsAdminAsync(string mobileNumber);
}