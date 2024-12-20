using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class InvitationRepo : IInvitationRepo
{
    public Task<bool> HasInvitationAsync(string mobileNumber)
    {
        return Task.FromResult(true);
    }
}