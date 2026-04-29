using LibraryApp.Catalog.Application.Books.Queries.Mappers;
using LibraryApp.Catalog.Domain.interfaces;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Queries.GetAll;

public class GetAllBooksHandler(IBookRepo bookRepo) : IRequestHandler<GetAllBooksQuery, Result<PagedResult<BookDto>>>
{
    public async Task<Result<PagedResult<BookDto>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var pagedBooks = await bookRepo.GetAllAsync(request);
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