namespace LibraryApp.Shared.Contracts.Dtos;

public record MemberDto(
    Guid Id,
    string FullName,
    string Email
);