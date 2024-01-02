﻿using Domain.Interfaces;
using System.Data;
using Domain.Entities;
using Dapper;

namespace Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly IDbConnection _connection;

    public UserRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<UserEntity?> GetAsync(string name)
    {
        var sql = "SELECT * FROM \"Users\" WHERE \"Name\" = @name AND \"IsDeleted\" = FALSE;";
        
        return await _connection.QuerySingleOrDefaultAsync<UserEntity>(sql, new { name = name });
    }

    public async Task<UserEntity> CreateAsync(UserEntity user)
    {
        string sql = "INSERT INTO \"Users\" (\"Name\", \"Address\") VALUES (@Name, @Address) RETURNING *;";

        return await _connection.QuerySingleAsync<UserEntity>(sql, user);
    }
}