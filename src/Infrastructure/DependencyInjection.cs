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
        // string dbConnectionString = Configuration.GetConnectionString("PostgreConnection") ?? throw new ArgumentNullException();

        string dbConnectionString = "User ID=postgres;Password=LabasRytas123;Host=localhost;Port=5432;Database=DoggoDollarsDB;"; // TODO: replace from hardcoded
        services.AddTransient<IDbConnection>(sp => new NpgsqlConnection(dbConnectionString));
        EnsureDatabase.For.PostgresqlDatabase(dbConnectionString);
        var upgrader = DeployChanges.To
            .PostgresqlDatabase(dbConnectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToNowhere()
            .Build();
        var result = upgrader.PerformUpgrade();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
    }
}
