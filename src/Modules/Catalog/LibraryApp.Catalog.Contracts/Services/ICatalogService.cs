using LibraryApp.Shared.Contracts.Dtos;

using LibraryApp.Shared.Contracts.Primitives;
namespace LibraryApp.Catalog.Contracts.Services;

public interface ICatalogService
{
    Task<Result<BookDto>> GetBookAsync(Guid bookId, CancellationToken ct);
    Task<Result> MarkBookUnavailableAsync(Guid bookId, CancellationToken ct);
    Task<Result> MarkBookAvailableAsync(Guid bookId, CancellationToken ct);
}