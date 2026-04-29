using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Domain.Entities;

namespace LibraryApp.Catalog.Application.Interfaces;

public interface ICatalogService
{
    Task<Result<BookDto>> GetBookAsync(Guid bookId, CancellationToken ct);
    Task<Result<Guid>> MarkBookUnavailableAsync(Guid bookId, CancellationToken ct);
    Task<Result<Guid>> MarkBookAvailableAsync(Guid bookId, CancellationToken ct);
}