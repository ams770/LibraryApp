using LibraryApp.Members.Application.Members.Commands.AddMember;
using LibraryApp.Members.Application.Members.Commands.EditMember;
using LibraryApp.Members.Application.Members.Queries.GetAll;
using LibraryApp.Members.Application.Members.Queries.GetByEmail;
using LibraryApp.Members.Application.Members.Queries.GetById;
using LibraryApp.Members.Contracts.Requests;
using LibraryApp.Members.Contracts.Services;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Members.Infrastructure.Services;

public class MemberApi(ISender sender) : IMemberApi
{
    public Task<Result<PagedResult<MemberDto>>> GetAllMembersAsync(PagedRequest query, CancellationToken ct = default)
        => sender.Send(new GetAllMembersQuery(query.Page, query.PageSize, query.SearchTerm), ct);

    public Task<Result<MemberDto>> GetMemberByIdAsync(Guid memberId, CancellationToken ct = default)
        => sender.Send(new GetMemberByIdQuery(memberId), ct);

    public Task<Result<MemberDto>> GetMemberByEmailAsync(string email, CancellationToken ct = default)
        => sender.Send(new GetMemberByEmailQuery(email), ct);

    public Task<Result<Guid>> AddMemberAsync(AddMemberRequestContract contract, CancellationToken ct = default)
        => sender.Send(new AddMemberCommand(contract.FullName, contract.Email), ct);

    public Task<Result> EditMemberAsync(EditMemberRequestContract contract, CancellationToken ct = default)
        => sender.Send(new EditMemberCommand(contract.Id, contract.FullName, contract.Email), ct);
}