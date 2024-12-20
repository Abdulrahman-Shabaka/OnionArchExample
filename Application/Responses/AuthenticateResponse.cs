namespace Application.Responses;

public record AuthenticateResponse(string AccessToken, string RefreshToken);