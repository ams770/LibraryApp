using LibraryApp.Borrowing.Application.Interfaces;
using LibraryApp.Borrowing.Domain.Interfaces;
using LibraryApp.Catalog.Contracts.Services;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Borrowing.Application.Loans.Commands.ReturnBook;

public class ReturnBookHandler(IBorrowingRepo borrowingRepo, IUnitOfWork unitOfWork)
    : IRequestHandler<ReturnBookCommand, Result>
{
    public async Task<Result> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
    {
        var loan = await borrowingRepo.GetByIdAsync(request.LoanId);
        if (loan is null) return Result.Failure("Loan is not found");
        
        loan.Return();
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}