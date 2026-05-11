using LibraryApp.Borrowing.Contracts.Requests;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;

namespace LibraryApp.Borrowing.Contracts.Services;

public interface IBorrowingApi
{
    Task<Result> ReturnLoanAsync(Guid id, CancellationToken ct);
    Task<Result<Guid>> AddLoanAsync(AddLoanRequestContract request, CancellationToken ct);
    Task<Result<PagedResult<LoanDto>>> GetAllLoansAsync(LoanPagedRequestContract request, CancellationToken ct);
}