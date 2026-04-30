using LibraryApp.Catalog.Application.Books.Commands.AddBook;
using LibraryApp.Catalog.Application.Interfaces;
using LibraryApp.Catalog.Contracts.Services;
using LibraryApp.Catalog.Infrastructure.Persistence;
using LibraryApp.Catalog.Infrastructure.Persistence.Repositories;
using LibraryApp.Catalog.Infrastructure.Services;
using LibraryApp.Catalog.Domain.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.Catalog.Infrastructure;

public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Database
        services.AddDbContext<CatalogDbContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("Default")));

        // Repositories
        services.AddScoped<IBookRepo, BookRepo>();
        services.AddScoped<IAuthorRepo, AuthorRepo>();

        // Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // internal module services
        services.AddScoped<ICatalogService, CatalogService>();
        services.AddScoped<ICatalogApi, CatalogApi>();

        // scans Application layer for all MediatR handlers
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(
                typeof(AddBookCommand).Assembly));

        return services;
    }
}