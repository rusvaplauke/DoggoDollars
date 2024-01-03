using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Data;

namespace Infrastructure.Repositories;

internal class TransactionRepository : ITransactionRepository
{
    private readonly IDbConnection _connection;

    public TransactionRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task RegisterAsync(TransactionEntity transaction)
    {
        var sql = "INSERT INTO \"Transactions\" (\"TypeId\", \"CorrespondingAccount\", \"Account\", \"Amount\", \"Fees\", \"Timestamp\") VALUES (@TypeId, @CorrespondingAccount, @Account, @Amount, @Fees, @Timestamp);";

        await _connection.ExecuteAsync(sql, transaction);
    }

    public async Task<List<TransactionEntity>> GetAsync()
    {
        return (await _connection.QueryAsync<TransactionEntity>("SELECT * FROM \"Transactions\";")).ToList();
    }

    public async Task<List<TransactionEntity>> GetAsync(int id)
    {
        var sql = "SELECT \"Transactions\".\"Id\", \"Timestamp\", \"Transactions\".\"TypeId\", \"CorrespondingAccount\", \"Account\", \"Amount\", \"Fees\" FROM \"Transactions\" JOIN \"Accounts\" ON \"Transactions\".\"Account\" = \"Accounts\".\"Id\" WHERE \"Accounts\".\"UserId\" = @id;";

        return (await _connection.QueryAsync<TransactionEntity>(sql, new { id = id })).ToList();
    }
}
