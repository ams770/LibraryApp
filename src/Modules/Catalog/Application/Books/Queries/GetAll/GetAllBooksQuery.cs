using LibraryApp.Shared.Contracts.Primitives;
using LibraryApp.Shared.Contracts.Dtos;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Queries.GetAll;

public record GetAllBooksQuery(
    int Page,
    int PageSize,
    string? SearchTerm,
    Guid? AuthorId) : IRequest<Result<PagedResult<BookDto>>>;