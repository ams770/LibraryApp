using LibraryApp.Catalog.Contracts.Requests;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;

namespace LibraryApp.Catalog.Contracts.Services;

public interface ICatalogApi
{
    // Books
    Task<Result<Guid>> AddBookAsync(string title, Guid authorId, bool isAvailable, CancellationToken ct = default);
    Task<Result<BookDto>> GetBookByIdAsync(Guid bookId, CancellationToken ct = default);

    Task<Result<PagedResult<BookDto>>> GetAllBooksAsync(
        BookPagedRequestContract query, CancellationToken ct = default);

    Task<Result> MarkBookAvailableAsync(Guid bookId, CancellationToken ct = default);
    Task<Result> MarkBookUnavailableAsync(Guid bookId, CancellationToken ct = default);

    // Authors
    Task<Result<Guid>> AddAuthorAsync(string name, CancellationToken ct = default);
    Task<Result> EditAuthorAsync(Guid authorId, string name, CancellationToken ct = default);
    Task<Result<PagedResult<AuthorDto>>> GetAllAuthorsAsync(PagedRequest query, CancellationToken ct = default);
}