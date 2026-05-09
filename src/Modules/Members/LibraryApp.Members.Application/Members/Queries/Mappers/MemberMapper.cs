using LibraryApp.Members.Domain.Entities;
using LibraryApp.Shared.Contracts.Dtos;

namespace LibraryApp.Members.Application.Members.Queries.Mappers;

public static class MemberMapper
{
    public static MemberDto ToDto(this Member member) => new(
        member.Id,
        member.FullName,
        member.Email
    );
}