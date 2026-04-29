using LibraryApp.Shared.Domain.Entities;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Commands.MarkBookAsAvailable;

public record MarkBookAsAvailableCommand(Guid BookId) : IRequest<Result<Guid>>;