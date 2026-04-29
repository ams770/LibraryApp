using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Authors.Queries.GetAll;

public class GetAllAuthorsQuery : PagedRequest, IRequest<Result<PagedResult<AuthorDto>>>;