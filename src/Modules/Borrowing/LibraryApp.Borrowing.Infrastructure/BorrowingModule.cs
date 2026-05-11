using LibraryApp.Borrowing.Application.Interfaces;
using LibraryApp.Borrowing.Application.Loans.Commands.AddLoan;
using LibraryApp.Borrowing.Contracts.Services;
using LibraryApp.Borrowing.Domain.Interfaces;
using LibraryApp.Borrowing.Infrastructure.Persistence;
using LibraryApp.Borrowing.Infrastructure.Persistence.Repositories;
using LibraryApp.Borrowing.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace LibraryApp.Borrowing.Infrastructure;

public static class BorrowingModule
{
    public static void AddBorrowingModule(this IServiceCollection services, IConfiguration configuration)
    {
        // Database
        services.AddDbContext<BorrowingDbContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("Default")));

        // Repositories
        services.AddScoped<IBorrowingRepo, BorrowingRepo>();

        // Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        // public api
        services.AddScoped<IBorrowingApi, BorrowingApi>();

        // scans Application layer for all MediatR handlers
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(
                typeof(AddLoanCommand).Assembly));
    }
}
