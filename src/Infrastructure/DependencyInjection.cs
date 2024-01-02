using DbUp;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;
using System.Reflection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        // TODO: replace from hardcoded
        string dbConnectionString = "User ID=postgres;Password=LabasRytas123;Host=localhost;Port=5432;Database=DoggoDollarsDB;"; 
        services.AddTransient<IDbConnection>(sp => new NpgsqlConnection(dbConnectionString));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
    }
}
