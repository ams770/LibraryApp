using LibraryApp.Members.Application.Interfaces;
using LibraryApp.Members.Domain.Interfaces;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Members.Application.Members.Commands.EditMember;

public class EditMemberHandler(IUnitOfWork unitOfWork, IMemberRepo memberRepo)
    : IRequestHandler<EditMemberCommand, Result>
{
    public async Task<Result> Handle(EditMemberCommand request, CancellationToken cancellationToken)
    {
        // Check if the email is used before
        var existMember = await memberRepo.GetByIdAsync(request.Id);
        if(existMember is null) return Result.Failure("Member is not found");
        
        existMember.SetEmailAddress(request.Email);
        existMember.SetFullName(request.FullName);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}