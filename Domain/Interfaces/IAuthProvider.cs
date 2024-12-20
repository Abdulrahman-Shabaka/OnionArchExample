namespace Domain.Interfaces;

public interface IAuthProvider
{
    Task<string> GetVerifiedMobileNumber(string idToken);
}