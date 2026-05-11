namespace LibraryApp.Borrowing.Contracts.Requests;

public record AddLoanRequestContract(Guid BookId, Guid MemberId, DateTime DueDate);