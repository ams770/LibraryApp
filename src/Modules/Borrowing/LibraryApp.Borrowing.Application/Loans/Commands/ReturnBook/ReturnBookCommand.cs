using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Borrowing.Application.Loans.Commands.ReturnBook;

public record ReturnBookCommand(Guid LoanId) : IRequest<Result>;