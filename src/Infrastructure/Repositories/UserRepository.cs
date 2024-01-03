using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Data;

namespace Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly IDbConnection _connection;

    public UserRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<UserEntity?> GetByNameAsync(string name)
    {
        var sql = "SELECT * FROM \"Users\" WHERE \"Name\" = @name AND \"IsDeleted\" = FALSE;";

        return await _connection.QuerySingleOrDefaultAsync<UserEntity>(sql, new { name = name });
    }

    public async Task<UserEntity?> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM \"Users\" WHERE \"Id\" = @id AND \"IsDeleted\" = FALSE;";

        return await _connection.QuerySingleOrDefaultAsync<UserEntity>(sql, new { id = id });
    }

    public async Task<UserEntity?> GetByIdIncludeDeletedAsync(int id)
    {
        var sql = "SELECT * FROM \"Users\" WHERE \"Id\" = @id;";

        return await _connection.QuerySingleOrDefaultAsync<UserEntity>(sql, new { id = id });
    }

    public async Task<UserEntity> CreateAsync(UserEntity user)
    {
        string sql = "INSERT INTO \"Users\" (\"Name\", \"Address\") VALUES (@Name, @Address) RETURNING *;";

        return await _connection.QuerySingleAsync<UserEntity>(sql, user);
    }
}
