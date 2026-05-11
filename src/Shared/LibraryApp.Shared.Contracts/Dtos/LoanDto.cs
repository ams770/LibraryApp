namespace LibraryApp.Shared.Contracts.Dtos;

public record LoanDto(
    Guid Id,
    Guid BookId,
    Guid MemberId,
    DateTime BorrowedAt,
    DateTime ReturnedAt,
    DateTime DueDate,
    string Status
);