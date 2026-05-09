using LibraryApp.Shared.Domain.Interfaces;

namespace LibraryApp.Members.Domain.Events;

public class MemberCreatedDomainEvent(Guid MemberId) : IDomainEvent;