using LibraryApp.Members.Application.Members.Queries.Mappers;
using LibraryApp.Members.Domain.Interfaces;
using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Members.Application.Members.Queries.Email;

public class GetMemberByIdHandler(IMemberRepo memberRepo) : IRequestHandler<GetMemberByIdQuery, Result<MemberDto>>
{
    public async Task<Result<MemberDto>> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
    {
        var member = await memberRepo.GetByIdAsync(request.Id);
        return member is null
            ? Result<MemberDto>.Failure("Member is not found!")
            : Result<MemberDto>.Success(member.ToDto());
    }
}