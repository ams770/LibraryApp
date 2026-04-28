using LibraryApp.Catalog.Application.Interfaces;
using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Catalog.Domain.interfaces;
using LibraryApp.Shared.Domain;
using MediatR;

namespace LibraryApp.Catalog.Application.Authors.Commands.EditAuthor;

public class EditAuthorService(IUnitOfWork unitOfWork, IAuthorRepo authorRepo)
    : IRequestHandler<EditAuthorCommand, Result<object>>
{
    public async Task<Result<object>> Handle(EditAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = Author.Create(request.FullName);
        await authorRepo.AddAsync(author);
        await unitOfWork.SaveChangesAsync();
        return Result<object>.Success(null);
    }
}