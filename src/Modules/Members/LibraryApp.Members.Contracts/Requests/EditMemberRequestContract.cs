namespace LibraryApp.Members.Contracts.Requests;

public record EditRequestMemberContract(Guid Id, string FullName, string Email);