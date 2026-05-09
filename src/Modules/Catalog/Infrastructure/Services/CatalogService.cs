using LibraryApp.Catalog.Application.Books.Commands.MarkBookAsAvailable;
using LibraryApp.Catalog.Application.Books.Commands.MarkBookAsUnAvailable;
using LibraryApp.Catalog.Application.Books.Queries.GetById;
using LibraryApp.Catalog.Contracts.Services;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Infrastructure.Services;

public class CatalogService(ISender sender) : ICatalogService
{
    public Task<Result<BookDto>> GetBookByIdAsync(Guid bookId, CancellationToken ct) =>
        sender.Send(new GetBookByIdQuery(bookId), ct);

    public Task<Result> MarkBookUnavailableAsync(Guid bookId, CancellationToken ct) =>
        sender.Send(new MarkBookAsUnAvailableCommand(bookId), ct);

    public Task<Result> MarkBookAvailableAsync(Guid bookId, CancellationToken ct) =>
        sender.Send(new MarkBookAsAvailableCommand(bookId), ct);
}