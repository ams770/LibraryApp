namespace LibraryApp.Members.Contracts.Requests;

public record EditMemberRequestContract(Guid Id, string FullName, string Email);