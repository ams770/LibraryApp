using LibraryApp.Members.Domain.Events;
using LibraryApp.Shared.Domain.Entities;
using LibraryApp.Shared.Domain.Exceptions;
using LibraryApp.Shared.Domain.Validation;

namespace LibraryApp.Members.Domain;


public class Member : Entity<Guid>
{
    public string FullName { get; private set; }
    public string Email { get; private set; }

    private Member()
    {
    }

    public static Member Create(string fullName, string email)
    {
        ValidateFullName(fullName);
        ValidateEmailAddress(email);
        var member = new Member
        {
            Id = Guid.NewGuid(),
            FullName = fullName,
            Email = email,
        };

        member.RaiseDomainEvent(new MemberCreatedDomainEvent(member.Id));
        return member;
    }


    public void SetFullName(string fullName)
    {
        ValidateFullName(fullName);
        FullName = fullName;
    }

    public void SetEmailAddress(string email)
    {
        ValidateEmailAddress(email);
        Email = email;
    }


    private static void ValidateFullName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new DomainException("Full name cannot be empty.");
        if (fullName.Length > 120)
            throw new DomainException("Full name cannot be longer than 120 characters.");
    }

    private static void ValidateEmailAddress(string email)
    {
        var isValid = RegexPatterns.Email().IsMatch(email);
        if (!isValid)
            throw new DomainException("Email address is not valid.");
    }
}