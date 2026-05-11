using LibraryApp.Borrowing.Application.Loans.Queries.Mappers;
using LibraryApp.Borrowing.Domain.Common;
using LibraryApp.Borrowing.Domain.Interfaces;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Borrowing.Application.Loans.Queries.GetAll;

public class GetAllLoansHandler(IBorrowingRepo borrowingRepo) : IRequestHandler<GetAllLoansQuery, Result<PagedResult<LoanDto>>>
{
    public async Task<Result<PagedResult<LoanDto>>> Handle(GetAllLoansQuery request, CancellationToken ct)
    {
        // map the query
        var query = new LoanPagedRequest
        {
            Page = request.Page,
            PageSize = request.PageSize,
            SearchTerm = request.SearchTerm,
            BookId = request.BookId,
            MemberId = request.MemberId,
        };

        var result = await borrowingRepo.GetAllAsync(query);

        var mappedItemsResult = new PagedResult<LoanDto>
        {
            Page = result.Page,
            PageSize = result.PageSize,
            TotalCount = result.TotalCount,

            Items = result.Items.Select(item => item.ToDto()).ToList(),
        };
        
        return Result<PagedResult<LoanDto>>.Success(mappedItemsResult);         
    }
}