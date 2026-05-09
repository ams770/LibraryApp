using LibraryApp.Members.Domain.Entities;
using LibraryApp.Members.Domain.Interfaces;
using LibraryApp.Members.Application.Interfaces;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Members.Application.Members.Commands.AddMember;

public class AddMemberHandler(IUnitOfWork unitOfWork, IMemberRepo memberRepo)
    : IRequestHandler<AddMemberCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddMemberCommand request, CancellationToken cancellationToken)
    {
        // Apply business layer rules first -> checks that the email is valid 
        var member = Member.Create(request.FullName, request.Email);
        // If passed -> Check if the valid email is used before
        var existMember = await memberRepo.GetByEmailAsync(request.Email);
        if (existMember != null) return Result<Guid>.Failure("Email already exists");
        // -
        await memberRepo.AddAsync(member);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<Guid>.Success(member.Id);
    }
}