namespace Infrastructure.Db;

public record RevokedAccountEntity(
    string Id,
    long RevokedTime
);