using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        var sql = "INSERT INTO \"Transactions\" (\"TypeId\", \"FromAccount\", \"ToAccount\", \"Amount\", \"Fees\", \"Timestamp\") VALUES (@TypeId, @FromAccount, @ToAccount, @Amount, @Fees, @Timestamp);";

        await _connection.ExecuteAsync(sql, transaction);
    }

   public async Task<List<TransactionEntity>> GetAsync()
    {
        return (await _connection.QueryAsync<TransactionEntity>("SELECT * FROM \"Transactions\";")).ToList();
    }

    public async Task<List<TransactionEntity>> GetAsync(int id)
    {
       
        
        // return (await _connection.QueryAsync<TransactionEntity>("SELECT * FROM \"Transactions\";")).ToList();
    }
}
