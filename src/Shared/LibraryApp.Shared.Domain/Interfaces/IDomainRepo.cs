

namespace LibraryApp.Shared.Domain.Interfaces;

public interface IDomainRepo<T>
{
    Task AddAsync(T entity);
    Task<T?> GetByIdAsync(Guid id);
}