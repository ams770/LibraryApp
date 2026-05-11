using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Borrowing.Application.Loans.Queries.GetAll;

public record GetAllLoansQuery(
    int Page,
    int PageSize,
    string? SearchTerm,
    Guid? BookId,
    Guid? MemberId,
    DateTime? FromDate,
    DateTime? ToDate
) : IRequest<Result<PagedResult<LoanDto>>>;