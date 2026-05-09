using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Queries.GetById;

public record GetBookByIdQuery(Guid BookId) : IRequest<Result<BookDto>>;