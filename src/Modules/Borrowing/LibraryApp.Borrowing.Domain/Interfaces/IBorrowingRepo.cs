using LibraryApp.Borrowing.Domain.Common;
using LibraryApp.Borrowing.Domain.Entities;
using LibraryApp.Shared.Contracts.Primitives;
using LibraryApp.Shared.Domain.Interfaces;

namespace LibraryApp.Borrowing.Domain.Interfaces;

public interface IBorrowingRepo: IDomainRepo<Loan>
{
    public Task<PagedResult<Loan>> GetAllAsync(LoanPagedRequest query);
}