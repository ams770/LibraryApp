using LibraryApp.Members.Application.Interfaces;
using LibraryApp.Members.Application.Members.Commands.AddMember;
using LibraryApp.Members.Contracts.Services;
using LibraryApp.Members.Domain.Interfaces;
using LibraryApp.Members.Infrastructure.Persistence;
using LibraryApp.Members.Infrastructure.Persistence.Repositories;
using LibraryApp.Members.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.Members.Infrastructure;

public static class MemberModule
{
    public static void AddMemberModule(this IServiceCollection services, IConfiguration configuration)
    {
        // Database
        services.AddDbContext<MemberDbContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("Default")));

        // Repositories
        services.AddScoped<IMemberRepo, MemberRepo>();

        // Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // internal module services
        services.AddScoped<IMemberService, MemberService>();
        // public api
        services.AddScoped<IMemberApi, MemberApi>();

        // scans Application layer for all MediatR handlers
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(
                typeof(AddMemberCommand).Assembly));
    }
}
