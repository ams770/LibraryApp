using LibraryApp.Catalog.Domain.Common;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Domain.Entities;
using MediatR;

namespace LibraryApp.Catalog.Application.Books.Queries.GetAll;

public class GetAllBooksQuery: BookPagedRequest, IRequest<Result<PagedResult<BookDto>>>;