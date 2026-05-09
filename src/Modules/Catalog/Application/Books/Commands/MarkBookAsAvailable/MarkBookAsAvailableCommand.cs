using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Commands.MarkBookAsAvailable;

public record MarkBookAsAvailableCommand(Guid BookId) : IRequest<Result>;