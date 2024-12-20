using Domain.Interfaces;

namespace Infrastructure.Services.Firebase;

public class FirebaseAuthProvider : IAuthProvider
{
    public Task<string> GetVerifiedMobileNumber(string idToken)
    {
        return Task.FromResult("verified phone number");
    }
}