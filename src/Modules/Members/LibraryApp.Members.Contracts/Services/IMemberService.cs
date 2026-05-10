using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;

namespace LibraryApp.Members.Contracts.Services;

public interface IMemberService
{
    public Task<Result<MemberDto>> GetMemberByIdAsync(Guid memberId, CancellationToken ct = default);
}