using LibraryApp.Members.Contracts.Requests;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;

namespace LibraryApp.Members.Contracts.Services;

public interface IMemberApi
{
    Task<Result<PagedResult<MemberDto>>> GetAllMembersAsync(PagedRequest query, CancellationToken ct);
    Task<Result<MemberDto>> GetMemberByIdAsync(Guid memberId, CancellationToken ct);
    Task<Result<MemberDto>> GetMemberByEmailAsync(string email, CancellationToken ct);
    Task<Result<Guid>> AddMemberAsync(AddMemberRequestContract contract, CancellationToken ct);
    Task<Result> EditMemberAsync(EditMemberRequestContract contract, CancellationToken ct);
}