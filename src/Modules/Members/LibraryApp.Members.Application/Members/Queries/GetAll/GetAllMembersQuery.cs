using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Members.Application.Members.Queries.GetAll;

public record GetAllMembersQuery(
    int Page,
    int PageSize,
    string? SearchTerm
) : IRequest<Result<PagedResult<MemberDto>>>;