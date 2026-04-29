using LibraryApp.Catalog.Domain.Common;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Queries.GetAll;

public class GetAllBooksQuery: BookPagedRequest, IRequest<Result<PagedResult<BookDto>>>;