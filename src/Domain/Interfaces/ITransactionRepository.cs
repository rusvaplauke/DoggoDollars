using Domain.Entities;

namespace Domain.Interfaces;

public interface ITransactionRepository
{
    Task RegisterAsync(TransactionEntity transaction);
}
