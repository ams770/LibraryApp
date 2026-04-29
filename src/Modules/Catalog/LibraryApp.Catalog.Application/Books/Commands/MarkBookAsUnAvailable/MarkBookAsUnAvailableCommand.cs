using LibraryApp.Shared.Domain.Entities;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Commands.MarkBookAsUnAvailable;

public record MarkBookAsUnAvailableCommand(Guid BookId) : IRequest<Result<Guid>>;