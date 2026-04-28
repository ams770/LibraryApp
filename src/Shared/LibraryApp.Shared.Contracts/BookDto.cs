namespace LibraryApp.Shared.Contracts;

public record BookDto(
    Guid Id,
    string Title,
    string Author,
    bool IsAvailable
);