namespace LibraryApp.Catalog.Application.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}