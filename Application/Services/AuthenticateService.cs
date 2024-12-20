using Application.Commands;
using Application.Responses;

using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models.Accounts;
using Domain.Services;

namespace Application.Services;

public class AuthenticateService(
    IAccountAuthenticationService accountAuthenticationService,
    IAccountRepo accountRepo,
    IInvitationRepo invitationRepo,
    IAuthProvider authProvider,
    IJWTGenerator jwtGenerator,
    ILogger logger) : IAuthenticateService
{
    public async Task<AuthenticateResponse> AuthenticateAsync(Authenticate command, CancellationToken cancellationToken)
    {
        logger.Log($"Handling authentication for IdToken: {command.IdToken}" );

        var mobileNumber = await authProvider.GetVerifiedMobileNumber(command.IdToken);
        logger.Log($"Mobile number verified: {mobileNumber}");

        var account = await GetOrCreateAccountAsync(mobileNumber, command);

        var tokens = account.Authenticate(accountAuthenticationService, jwtGenerator, command.DeviceId, command.DeviceType);

        await accountRepo.SaveAsync(account);
        logger.Log($"Authentication successful for account: {account.MobileNumber.Value}");

        return new AuthenticateResponse(tokens.AccessToken, tokens.RefreshToken);
    }

    private async Task<Account> GetOrCreateAccountAsync(string mobileNumber, Authenticate command)
    {
        logger.Log($"Fetching account by mobile number: {mobileNumber}");
        var account = await accountRepo.GetByMobileNumberAsync(mobileNumber);

        if (account != null)
            return account;

        return await CreateNewAccountAsync(mobileNumber, command.DeviceType, command.DeviceId);
    }

    private async Task<Account> CreateNewAccountAsync(string mobileNumber, string deviceType, string deviceId)
    {
        var isAdmin = await accountRepo.IsAdminAsync(mobileNumber);
        var hasNoInvitations = !await invitationRepo.HasInvitationAsync(mobileNumber);

        AssertIsAdminOrInvited(mobileNumber, isAdmin, hasNoInvitations);

        return Account.NewAccount(mobileNumber, isAdmin, deviceType, deviceId);
    }

    private void AssertIsAdminOrInvited(string mobileNumber, bool isAdmin, bool hasNoInvitations)
    {
        if (isAdmin || !hasNoInvitations) return;
        logger.WarningLog($"Account not invited: {mobileNumber}");
        throw new AppException.RequirementException("Account not invited to use the App");
    }
}