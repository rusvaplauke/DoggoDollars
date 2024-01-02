using Domain.Entities;

namespace Domain.Interfaces;

public interface IAccountRepository
{
    Task<int> CountByUserIdAsync(int id);
    Task<AccountEntity> CreateAsync(AccountEntity account);
}
