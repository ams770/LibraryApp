using LibraryApp.Catalog.Domain.Common;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Queries.GetAll;

public record GetAllBooksQuery(
    int Page,
    int PageSize,
    string? SearchTerm,
    Guid? AuthorId) : IRequest<Result<PagedResult<BookDto>>>;