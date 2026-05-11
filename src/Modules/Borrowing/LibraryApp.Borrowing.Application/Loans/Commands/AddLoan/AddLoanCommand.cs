using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Borrowing.Application.Loans.Commands.AddLoan;

public record AddLoanCommand(Guid BookId, Guid MemberId, DateTime DueDate) : IRequest<Result<Guid>>;