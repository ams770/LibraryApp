using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Commands.AddBook;

public record AddBookCommand(Guid AuthorId, string Title, bool IsAvailable) : IRequest<Result<Guid>>;