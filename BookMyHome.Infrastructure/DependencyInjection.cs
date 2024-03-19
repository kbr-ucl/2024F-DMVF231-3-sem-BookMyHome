﻿using BookMyHome.Application.Queries.Booking;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Infrastructure.Database;
using BookMyHome.Infrastructure.DomainServices;
using BookMyHome.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookMyHome.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Database
        // https://github.com/dotnet/SqlClient/issues/2239
        // https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
        // Add-Migration InitialMigration -Context BookMyHomeContext -Project BookMyHome.DatabaseMigration
        // Update-Database -Context BookMyHomeContext -Project BookMyHome.DatabaseMigration

        services.AddDbContext<BookMyHomeContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("BookMyHomeDbConnection"),
                x =>
                    x.MigrationsAssembly("BookMyHome.DatabaseMigration")));

        services.AddScoped<IBookingDomainService, BookingDomainService>();
        services.AddScoped<IBookingQuery, BookingQuery>();

        return services;
    }
}