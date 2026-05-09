using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Commands.MarkBookAsUnAvailable;

public record MarkBookAsUnAvailableCommand(Guid BookId) : IRequest<Result>;