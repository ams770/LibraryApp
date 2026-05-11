using LibraryApp.Borrowing.Domain.Entities;
using LibraryApp.Shared.Contracts.Dtos;

namespace LibraryApp.Borrowing.Application.Loans.Queries.Mappers;

public static class LoanMapper
{
    public static LoanDto ToDto(this Loan loan) => new(
        loan.Id,
        loan.BookId,
        loan.MemberId,
        loan.BorrowedAt,
        loan.ReturnedAt,
        loan.DueDate,
        loan.Status.ToString()
    );
}