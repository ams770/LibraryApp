using LibraryApp.Shared.Domain;
using MediatR;

namespace LibraryApp.Catalog.Application.Book.Commands.AddBook;

public record AddBookCommand(string Name, string Author, bool IsAvailable) : IRequest<Result<Guid>>;