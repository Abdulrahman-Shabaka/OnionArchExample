using Domain.Interfaces;
using Domain.Models.Accounts;
using Domain.Models.Devices;

namespace Infrastructure.Services.Firebase;

public class JwtGenerator : IJWTGenerator
{
    public string GenerateAccessToken(Account account, Device? device)
    {
        return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";
    }

    public string GenerateRefreshToken(Account account, Device? device)
    {
        return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";
    }
}