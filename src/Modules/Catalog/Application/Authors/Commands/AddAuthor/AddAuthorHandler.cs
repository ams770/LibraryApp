using LibraryApp.Catalog.Application.Interfaces;
using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Catalog.Domain.interfaces;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Authors.Commands.AddAuthor;

public class AddAuthorHandler(IUnitOfWork unitOfWork, IAuthorRepo authorRepo)
    : IRequestHandler<AddAuthorCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = Author.Create(request.FullName);
        await authorRepo.AddAsync(author);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<Guid>.Success(author.Id);
    }
}