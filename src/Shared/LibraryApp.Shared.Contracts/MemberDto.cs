namespace LibraryApp.Shared.Contracts;

public record MemberDto(
    Guid Id,
    string FullName,
    bool IsActive
);