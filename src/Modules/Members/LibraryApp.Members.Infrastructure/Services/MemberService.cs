using LibraryApp.Members.Application.Members.Queries.GetById;
using LibraryApp.Members.Contracts.Services;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Members.Infrastructure.Services;

public class MemberService(ISender sender) : IMemberService
{
    public Task<Result<MemberDto>> GetMemberByIdAsync(Guid memberId, CancellationToken ct = default)
    => sender.Send(new GetMemberByIdQuery(memberId), ct);
}