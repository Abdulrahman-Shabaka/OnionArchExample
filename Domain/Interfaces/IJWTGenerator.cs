using Domain.Models.Accounts;
using Domain.Models.Devices;

namespace Domain.Interfaces;

public interface IJWTGenerator
{
    string GenerateAccessToken(Account account, Device? device);
    string GenerateRefreshToken(Account account, Device? device);
}