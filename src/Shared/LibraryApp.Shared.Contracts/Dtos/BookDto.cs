namespace LibraryApp.Shared.Contracts.Dtos;

public record BookDto(
    Guid Id,
    string Title,
    bool IsAvailable,
    AuthorDto Author
);
