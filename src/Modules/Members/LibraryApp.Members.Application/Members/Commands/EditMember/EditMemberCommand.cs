using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Members.Application.Members.Commands.EditMember;

public record EditMemberCommand(Guid Id, string FullName, string Email) : IRequest<Result>;