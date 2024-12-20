using Application.Commands;
using Application.Responses;

namespace Application.Services;

public interface IAuthenticateService
{
    Task<AuthenticateResponse> AuthenticateAsync(Authenticate command, CancellationToken cancellationToken);
}