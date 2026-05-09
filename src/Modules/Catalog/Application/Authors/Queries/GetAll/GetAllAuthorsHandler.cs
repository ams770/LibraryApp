using LibraryApp.Catalog.Domain.interfaces;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Authors.Queries.GetAll;

public class GetAllAuthorsHandler(IAuthorRepo authorRepo)
    : IRequestHandler<GetAllAuthorsQuery, Result<PagedResult<AuthorDto>>>
{
    public async Task<Result<PagedResult<AuthorDto>>> Handle(GetAllAuthorsQuery request,
        CancellationToken cancellationToken)
    {
        // Fetch data from infra
        var authorsPaged = await authorRepo.GetAllAsync(request);
        // Map data to the app dto record
        var pagedItemsMapped = authorsPaged.Items.Select(item => item.ToDto()).ToList();
        // Handle the new result type
        var mappedPagedResult = new PagedResult<AuthorDto>
        {
            Items = pagedItemsMapped,
            Page = authorsPaged.Page,
            PageSize = authorsPaged.PageSize,
            TotalCount = authorsPaged.TotalCount,
        };
        
        return Result<PagedResult<AuthorDto>>.Success(mappedPagedResult);
    }
}