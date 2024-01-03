using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Data;

namespace Infrastructure.Repositories;

internal class AccountRepository : IAccountRepository
{
    private readonly IDbConnection _connection;

    public AccountRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<int> CountByUserIdAsync(int id)
    {
        var sql = "SELECT COUNT (*) FROM \"Accounts\" WHERE \"UserId\" = @id AND \"IsDeleted\" = FALSE;";

        return await _connection.QuerySingleOrDefaultAsync<int>(sql, new { id = id });
    }

    public async Task<AccountEntity> CreateAsync(AccountEntity account)
    {
        var sql = "INSERT INTO \"Accounts\" (\"Id\", \"UserId\", \"TypeId\") VALUES (@Id, @UserId, @TypeId) RETURNING *;";

        return await _connection.QuerySingleAsync<AccountEntity>(sql, account);
    }

    public async Task<AccountEntity?> GetAsync(string? id)
    {
        var sql = "SELECT * FROM \"Accounts\" WHERE \"Id\" = @id AND \"IsDeleted\" = FALSE;";

        return await _connection.QuerySingleOrDefaultAsync<AccountEntity>(sql, new { id = id });
    }

    public async Task<AccountEntity> ChangeBalanceAsync(string? id, decimal amount)
    {
        var sql = "UPDATE \"Accounts\" SET \"Balance\" = \"Balance\" + @amount WHERE \"Id\" = @id RETURNING *;";

        return await _connection.QuerySingleAsync<AccountEntity>(sql, new { id = id, amount = amount });
    }
}
