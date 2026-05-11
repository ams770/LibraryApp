using LibraryApp.Borrowing.Contracts.Requests;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;

namespace LibraryApp.Borrowing.Contracts.Services;

public interface IBorrowingApi
{
    Task<Result<Guid>> AddAsync(AddLoanRequestContract request, CancellationToken ct);
    Task<Result<PagedResult<LoanDto>>> GetAllAsync(LoanPagedRequestContract request, CancellationToken ct);
}