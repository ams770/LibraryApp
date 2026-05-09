using LibraryApp.Members.Application.Members.Queries.Mappers;
using LibraryApp.Members.Domain.Interfaces;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Members.Application.Members.Queries.GetByEmail;

public class GetMemberByEmailHandler(IMemberRepo memberRepo) : IRequestHandler<GetMemberByEmailQuery, Result<MemberDto>>
{
    public async Task<Result<MemberDto>> Handle(GetMemberByEmailQuery request, CancellationToken cancellationToken)
    {
        var member = await memberRepo.GetByEmailAsync(request.Email);
        return member is null
            ? Result<MemberDto>.Failure("Member is not found!")
            : Result<MemberDto>.Success(member.ToDto());
    }
}