namespace Domain.Interfaces;

public interface IInvitationRepo
{
    Task<bool> HasInvitationAsync(string mobileNumber);
}