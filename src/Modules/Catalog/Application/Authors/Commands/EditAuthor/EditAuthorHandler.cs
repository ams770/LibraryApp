using LibraryApp.Catalog.Application.Interfaces;
using LibraryApp.Catalog.Domain.Entities;
using LibraryApp.Catalog.Domain.interfaces;
using LibraryApp.Shared.Contracts.Primitives;
using MediatR;

namespace LibraryApp.Catalog.Application.Authors.Commands.EditAuthor;

public class EditAuthorHandler(IUnitOfWork unitOfWork, IAuthorRepo authorRepo)
    : IRequestHandler<EditAuthorCommand, Result>
{
    public async Task<Result> Handle(EditAuthorCommand request, CancellationToken cancellationToken)
    {
        
        var author = await authorRepo.GetByIdAsync(request.Id);
        if (author is null) return Result.Failure("Author not found");
        author.SetName(request.FullName);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}