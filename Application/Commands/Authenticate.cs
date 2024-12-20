namespace Application.Commands;

public record Authenticate(string IdToken, string DeviceId, string DeviceType);