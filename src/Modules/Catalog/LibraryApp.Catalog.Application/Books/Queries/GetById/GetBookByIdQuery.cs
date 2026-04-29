using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Queries.GetById;

public record GetBookByIdCommand(Guid BookId) : IRequest<Result<BookDto>>;