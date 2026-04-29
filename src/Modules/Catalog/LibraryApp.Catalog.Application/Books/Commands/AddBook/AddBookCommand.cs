using LibraryApp.Shared.Domain.Entities;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Commands.AddBook;

public record AddBookCommand(Guid AuthorId, string Title, bool IsAvailable) : IRequest<Result<Guid>>;