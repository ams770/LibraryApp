using LibraryApp.Catalog.Domain.Common;
using LibraryApp.Catalog.Domain.interfaces;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Domain;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Queries.GetAll;

public class GetAllBooksService(IBookRepo bookRepo) : IRequestHandler<GetAllBooksQuery, Result<PagedResult<BookDto>>>
{
    public async Task<Result<PagedResult<BookDto>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var pagedBooks = await bookRepo.GetAllAsync(request);
        var mappedItems = pagedBooks.Items.Select(item => item.ToDto()).ToList();
        var mappedResult = new PagedResult<BookDto>
        {
            Items = mappedItems,
            Page = request.Page,
            PageSize = request.PageSize,
            TotalCount = pagedBooks.TotalCount
        };
        
        return Result<PagedResult<BookDto>>.Success(mappedResult);
    }
}