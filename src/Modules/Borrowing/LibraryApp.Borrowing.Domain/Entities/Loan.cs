using LibraryApp.Borrowing.Domain.Enums;
using LibraryApp.Borrowing.Domain.Events;
using LibraryApp.Shared.Domain.Entities;
using LibraryApp.Shared.Domain.Exceptions;

namespace LibraryApp.Borrowing.Domain.Entities;

public class Loan : Entity<Guid>
{
    public Guid BookId { get; private set; }
    public Guid MemberId { get; private set; }
    public DateTime BorrowedAt { get; private set; }
    public DateTime ReturnedAt { get; private set; }
    public DateTime DueDate { get; private set; }
    public LoanStatus Status { get; private set; }

    private Loan()
    {
    }

    public static Loan Create(Guid bookId, Guid memberId, DateTime dueDate)
    {
        if (dueDate <= DateTime.UtcNow)
            throw new DomainException("Due date must be in the future.");

        
        
        var loan = new Loan
        {
            Id = Guid.NewGuid(),
            BookId = bookId,
            MemberId = memberId,
            DueDate = dueDate,
            BorrowedAt = DateTime.UtcNow,
            Status = LoanStatus.Active,
        };

        loan.RaiseDomainEvent(new LoanCreatedDomainEvent(loan.Id, loan.BookId, loan.MemberId));
        
        return loan;
    }


    public void Return()
    {
        if (Status == LoanStatus.Returned)
            throw new DomainException("Loan is already returned.");

        
        ReturnedAt = DateTime.UtcNow;
        Status = LoanStatus.Returned;
        RaiseDomainEvent(new BookReturnedDomainEvent(Id, BookId));
    }
    
    public void MarkAsOverdue()
    {
        if (Status != LoanStatus.Active)
            throw new DomainException("Only active loans can be marked as overdue.");

        Status = LoanStatus.Overdue;
    }
    
}