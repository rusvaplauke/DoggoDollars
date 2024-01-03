using Domain.Entities;

namespace Domain.Interfaces;

public interface ITransactionRepository
{
    Task RegisterAsync(TransactionEntity transaction);
    Task<List<TransactionEntity>> GetAsync();
    Task<List<TransactionEntity>> GetAsync(int id);
}
