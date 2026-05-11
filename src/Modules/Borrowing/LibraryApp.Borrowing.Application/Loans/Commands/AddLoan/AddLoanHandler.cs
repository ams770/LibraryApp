using LibraryApp.Borrowing.Application.Interfaces;
using LibraryApp.Borrowing.Domain.Entities;
using LibraryApp.Borrowing.Domain.Interfaces;
using LibraryApp.Catalog.Contracts.Services;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Borrowing.Application.Loans.Commands.AddLoan;

public class AddLoanHandler(IBorrowingRepo borrowingRepo, IUnitOfWork unitOfWork, ICatalogService catalogService)
    : IRequestHandler<AddLoanCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddLoanCommand request, CancellationToken ct)
    {
        // Verify Book Exists
        var book = await catalogService.GetBookByIdAsync(request.BookId, ct);
        if (!book.IsSuccess) return Result<Guid>.Failure("Book not found");
        // Verify Book Available
        if (!(book.Value?.IsAvailable ?? false)) return Result<Guid>.Failure("Book is not available for borrowing");

        // Create the new loan
        var loan = Loan.Create(request.BookId, request.MemberId, request.DueDate);
        
        // Save changes => Notify all listeners
        await borrowingRepo.AddAsync(loan);
        await unitOfWork.SaveChangesAsync(ct);
        
        return Result<Guid>.Success(loan.Id);
    }
}