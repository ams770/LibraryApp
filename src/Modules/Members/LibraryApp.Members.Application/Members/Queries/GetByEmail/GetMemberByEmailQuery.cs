using LibraryApp.Shared.Contracts.Dtos;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Members.Application.Members.Queries.GetByEmail;

public record GetMemberByEmailQuery(string Email) : IRequest<Result<MemberDto>>;