using LibraryApp.Catalog.Application.Books.Queries.Mappers;
using LibraryApp.Catalog.Domain.Common;
using LibraryApp.Catalog.Domain.Interfaces;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Queries.GetAll;

public class GetAllBooksHandler(IBookRepo bookRepo) : IRequestHandler<GetAllBooksQuery, Result<PagedResult<BookDto>>>
{
    public async Task<Result<PagedResult<BookDto>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {

        // Map
        var domainQuery = new BookPagedRequest
        {
            Page = request.Page,
            PageSize = request.PageSize,
            SearchTerm = request.SearchTerm,
            AuthorId = request.AuthorId
        };
        // Call Domain
        var pagedBooks = await bookRepo.GetAllAsync(domainQuery);
        var mappedItems = pagedBooks.Items.Select(item => item.ToDto()).ToList();
        // map result 
        var mappedResult = new PagedResult<BookDto>
        {
            Items = mappedItems,
            Page = pagedBooks.Page,
            PageSize = pagedBooks.PageSize,
            TotalCount = pagedBooks.TotalCount
        };

        return Result<PagedResult<BookDto>>.Success(mappedResult);
    }
}