using LibraryApp.Shared.Contracts.Dtos;

using LibraryApp.Shared.Contracts.Primitives;
namespace LibraryApp.Catalog.Contracts;

public interface ICatalogService
{
    Task<Result<BookDto>> GetBookAsync(Guid bookId, CancellationToken ct);
    Task<Result<Guid>> MarkBookUnavailableAsync(Guid bookId, CancellationToken ct);
    Task<Result<Guid>> MarkBookAvailableAsync(Guid bookId, CancellationToken ct);
}