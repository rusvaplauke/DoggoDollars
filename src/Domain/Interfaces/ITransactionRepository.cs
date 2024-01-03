using Domain.Entities;
using System.Transactions;

namespace Domain.Interfaces;

public interface ITransactionRepository
{
    Task RegisterAsync(TransactionEntity transaction);
    Task<List<TransactionEntity>> GetAsync();
}
