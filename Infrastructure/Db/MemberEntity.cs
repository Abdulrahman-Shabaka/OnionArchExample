namespace Infrastructure.Db;

public record MemberEntity(
    string Id,
    List<string> Ancestors,
    string Parent,
    List<string> Children
);