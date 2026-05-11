using LibraryApp.Borrowing.Application.Loans.Commands.AddLoan;
using LibraryApp.Borrowing.Application.Loans.Queries.GetAll;
using LibraryApp.Borrowing.Contracts.Requests;
using LibraryApp.Borrowing.Contracts.Services;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Borrowing.Infrastructure.Services;

public class BorrowingApi(ISender sender) : IBorrowingApi
{
    public Task<Result<Guid>> AddAsync(AddLoanRequestContract request, CancellationToken ct = default)
        => sender.Send(new AddLoanCommand(request.BookId, request.MemberId, request.DueDate), ct);

    public Task<Result<PagedResult<LoanDto>>> GetAllAsync(LoanPagedRequestContract request,
        CancellationToken ct = default)
        => sender.Send(new GetAllLoansQuery(
            request.Page,
            request.PageSize,
            request.SearchTerm,
            request.BookId,
            request.MemberId,
            request.FromDate,
            request.ToDate
        ), ct);
}