using LibraryApp.Members.Domain.Entities;
using LibraryApp.Shared.Contracts.Primitives;
using LibraryApp.Shared.Domain.Interfaces;

namespace LibraryApp.Members.Domain.Interfaces;

public interface IMembersRepo : IDomainRepo<Member>
{
    public Task<Member?> GetByEmailAsync(string email);
    public Task<PagedResult<Member>> GetAllAsync(PagedRequest request);
}